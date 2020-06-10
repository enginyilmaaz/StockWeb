
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockWeb.Business.Abstract;
using StockWeb.Data.Entity;

namespace Stock.Web.Controllers
{

    [Route("api")]
    [EnableCors("AnyToAll")]
    public class APIController : Controller
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
                var product = _productService.GetById(id);

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
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null) isNotExist = false;
                return Ok(isNotExist);
            }
            catch
            {
                return BadRequest();
            }
        }

    }


}
