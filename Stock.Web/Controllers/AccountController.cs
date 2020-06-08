using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stock.Web.Models.Account;
using Stock.Web.Models.Product;
using StockWeb.Data.Entity;

namespace Stock.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Users> _userManager;
        private SignInManager<Users> _signInManager;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
          if(User.Identity.IsAuthenticated) return RedirectToAction("Index", "Admin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true,false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("","Hatalı eposta yada şifre");
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
            var user = new Users()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName =model.Email,
                isActive = true,

            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                TempData["message-title"] = "İşlem Başarılı";
                TempData["message-data"] = "Kayıt başarılı başarılı, giriş yapabilirsiniz.";
                TempData["message-type"] = "success";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

      


      
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

             return RedirectToAction("Index", "Home");

  
        }





        [Route("Account/Details")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserDetails()
        {


            var entity = await _userManager.GetUserAsync(User);

            if (entity == null)
            {
               return RedirectToAction("ErrorOccured", "Admin");
            }

            var model = new UserViewModel()
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


            var entity = await _userManager.GetUserAsync(User);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Admin");
            }



            entity.FirstName = model.UserDetailViewModel.FirstName;
            entity.LastName = model.UserDetailViewModel.LastName;
            entity.Email = model.UserDetailViewModel.Email;
            entity.UserName = model.UserDetailViewModel.Email;

             await _userManager.UpdateAsync(entity);

             TempData["message-title"] = "İşlem Başarılı";
             TempData["message-data"] = "Bilgi güncelleme başarılı";
             TempData["message-type"] = "success";

            return RedirectToAction("UserDetails");
        }



        [Route("Account/ChangePass")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePass(UserViewModel model)
        {


            var entity = await _userManager.GetUserAsync(User);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Admin");
            }

            var newPassword = _userManager.PasswordHasher.HashPassword(entity, model.ChangePassViewModel.Password);
           entity.PasswordHash = newPassword;
            var res = await _userManager.UpdateAsync(entity);

            if (res.Succeeded)
            {
                TempData["message-title"] = "İşlem Başarılı";
                TempData["message-data"] = "Şifre değiştirme başarılı";
                TempData["message-type"] = "success";
                return RedirectToAction("UserDetails");
            }

           return RedirectToAction("ErrorOccured", "Admin");
        }




    }
}
