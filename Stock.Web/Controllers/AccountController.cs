﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stock.Web.EmailServices;
using Stock.Web.Models.Account;
using StockWeb.Business.ToastMessage;
using StockWeb.Data.Entity;
using StockWeb.Data.ToastMessages;
using System;
using System.Threading.Tasks;

namespace Stock.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;

        }
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            Users user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı ile daha önce hesap oluşturulmamış");
                return View(model);
            }
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayınız.");
                    return View();
                }
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı eposta yada şifre");
                }


            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            Users user = new Users()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                isActive = true,

            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    UserToken = code

                });
                string fullUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, url);
                await _emailSender.SendEmailAsync(user.Email, "Hesap Onayı", $"<br/><br/>Hesabınızı onaylamak için lütfen <a href='{fullUrl}'>tıklayınız.</a>" +
                                                                             $"<br><br> <b>Bilgilendirme:</b> Bu link {DateTime.UtcNow.AddHours(3).AddDays(2).ToString("MM/dd/yyyy HH:mm:ss")} tarihine kadar geçerlidir. Bu süreden sonra tekrar onay isteği göndermeniz gerekecektir.");



                ToastMessageSender.ShowMessage(this, "success", AccountMessages.RegisterSuccess);
                return RedirectToAction("Login", "Account");
            }

            return View();
        }





        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");


        }


        public async Task<IActionResult> ConfirmEmail(string UserId, string UserToken)
        {
            if (UserId == null || UserToken == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            Users user = await _userManager.FindByIdAsync(UserId);

            if (user.EmailConfirmed)
            {

                ToastMessageSender.ShowMessage(this, "info", AccountMessages.AlreadyEmailConfirmed);
                return RedirectToAction("Login", "Account");
            }
            if (!await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.EmailConfirmationTokenProvider,
                "EmailConfirmation", UserToken))

            {
                ToastMessageSender.ShowMessage(this, "danger", AccountMessages.ConfirmEmailInvalidToken);
                return RedirectToAction("Login", "Account");
            }
            if (user != null)
            {
                IdentityResult result = await _userManager.ConfirmEmailAsync(user, UserToken);
                if (result.Succeeded)
                {
                    // cart objesini oluştur.


                    ToastMessageSender.ShowMessage(this, "success", AccountMessages.EmailConfirmSuccess);

                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("ErrorOccured", "Home");


        }



        [HttpPost]

        public async Task<IActionResult> ConfirmEmail(string email)
        {
            bool userExist = false;
            Users user = await _userManager.FindByEmailAsync(email);

            if (user.EmailConfirmed)
            {
                return Ok("isConfirmed");
            }

            if (user != null)
            {

                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    UserToken = code

                });
                string fullUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, url);
                await _emailSender.SendEmailAsync(user.Email, "Hesap Onayı", $"<br/><br/>Hesabınızı onaylamak için lütfen <a href='{fullUrl}'>tıklayınız.</a>" +
                  $"<br><br> <b>Bilgilendirme:</b> Bu link {DateTime.UtcNow.AddHours(3).AddDays(2).ToString("MM/dd/yyyy HH:mm:ss")} tarihine kadar geçerlidir. Bu süreden sonra tekrar onay isteği göndermeniz gerekecektir.");
                userExist = true;


            }

            return Ok(userExist);
        }



        [Route("Account/Details")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserDetails()
        {


            Users entity = await _userManager.GetUserAsync(User);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            UserViewModel model = new UserViewModel()
            {

                UserDetailViewModel = new UserDetailViewModel()
                {
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                },



            };




            return View(model);
        }






        [Route("Account/Details")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UserDetails(UserViewModel model)
        {


            Users entity = await _userManager.GetUserAsync(User);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }



            entity.FirstName = model.UserDetailViewModel.FirstName;
            entity.LastName = model.UserDetailViewModel.LastName;
            entity.Email = model.UserDetailViewModel.Email;
            entity.UserName = model.UserDetailViewModel.Email;

            await _userManager.UpdateAsync(entity);
            ToastMessageSender.ShowMessage(this, "success", AccountMessages.EditAccountSuccess);

            return RedirectToAction("UserDetails");
        }



        [Route("Account/ChangePass")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePass(UserViewModel model)
        {


            Users entity = await _userManager.GetUserAsync(User);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            string newPassword = _userManager.PasswordHasher.HashPassword(entity, model.ChangePassViewModel.Password);
            entity.PasswordHash = newPassword;
            IdentityResult res = await _userManager.UpdateAsync(entity);

            if (res.Succeeded)
            {
                ToastMessageSender.ShowMessage(this, "success", AccountMessages.ChangePassSuccess);
                return RedirectToAction("UserDetails");
            }

            return RedirectToAction("ErrorOccured", "Home");
        }


        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                ToastMessageSender.ShowMessage(this, "warning", AccountMessages.ForgotPassIsAuthenticated);
                return RedirectToAction("UserDetails");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {


            Users user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                ToastMessageSender.ShowMessage(this, "danger", AccountMessages.ForgotPassIsNotExistUser);
                return View();
            }

            string code = await _userManager.GeneratePasswordResetTokenAsync(user);

            string url = Url.Action("ResetPass", "Account", new
            {
                UserId = user.Id,
                Token = code
            });
            string fullUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, url);

            await _emailSender.SendEmailAsync(Email, "Parola Sıfırla", $"<br><br>Parolanızı yenilemek için linke <a href='{fullUrl}'>tıklayınız.</a>" +
             $"<br><br> <b>Bilgilendirme:</b> Bu link {DateTime.UtcNow.AddHours(3).AddHours(2).ToString("MM/dd/yyyy HH:mm:ss")} tarihine kadar geçerlidir. Bu süreden sonra tekrar şifre sıfırlama isteği göndermeniz gerekecektir.");

            ToastMessageSender.ShowMessage(this, "success", AccountMessages.ForgotPassEmailSendSuccess);


            return View();
        }



        public async Task<IActionResult> ResetPass(string UserId, string Token)
        {
            if (User.Identity.IsAuthenticated)
            {
                ToastMessageSender.ShowMessage(this, "warning", AccountMessages.ResetPassIsAuthenticated);
                return RedirectToAction("UserDetails");
            }
            if (UserId == null || Token == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            Users user = await _userManager.FindByIdAsync(UserId);


            if (!await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.PasswordResetTokenProvider,
                "ResetPassword", Token))

            {
                ToastMessageSender.ShowMessage(this, "danger", AccountMessages.ResetPassInvalidToken);
                return RedirectToAction("ForgotPassword", "Account");
            }



            UserResetPasswordModel model = new UserResetPasswordModel
            {
                _Token = Token,
                _UserId = UserId
            };


            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> ResetPass(UserResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Users user = await _userManager.FindByIdAsync(model._UserId);
            if (user == null)
            {
                ToastMessageSender.ShowMessage(this, "warning", AccountMessages.ResetPassIsNotExistUser);
                return RedirectToAction("Index", "Home");
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, model._Token, model.Password);

            if (result.Succeeded)
            {




                Microsoft.AspNetCore.Identity.SignInResult login = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (login.Succeeded)
                {
                    ToastMessageSender.ShowMessage(this, "success", AccountMessages.ResetPassSuccess);
                    return RedirectToAction("Index", "Admin");
                }
            }


            return View(model);
        }


    }
}
