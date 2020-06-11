
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockWeb.Business.Abstract;
using StockWeb.Data.Entity;
using System.Threading.Tasks;

namespace Stock.Web.Controllers
{

    [Route("api")]
    [EnableCors("AnyToAll")]
    public class APIController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly IProductService _productService;
        public APIController(IProductService productService, UserManager<Users> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }





        [Produces("application/json")]
        [HttpGet("Product/GetStockQuantity/{id}")]
        public IActionResult GetStockQuantity(int id)
        {
            try
            {
                Products product = _productService.GetById(id);

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [HttpGet("Account/CheckNotRegisteredbyEmail/")]
        public async Task<IActionResult> GetStockQuantity(string email)
        {
            try
            {
                bool isNotExist = true;
                Users user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    isNotExist = false;
                }

                return Ok(isNotExist);
            }
            catch
            {
                return BadRequest();
            }

        }







        [Produces("application/json")]
        [HttpGet("Account/ConfirmEmail/")]
        public async Task<IActionResult> ConfirmEmail(string email)
        {
            try
            {
                bool isNotExist = false;
                Users user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    isNotExist = true;
                }

                return Ok(isNotExist);
            }
            catch
            {
                return BadRequest();
            }
        }



    }


}
