using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockWeb.Business.Abstract;

namespace Stock.Web.Controllers
{

    [Route("api")] 
    public class APIController : Controller
    {
        private IProductService _productService;
        public APIController(IProductService productService)
        {
            _productService = productService;

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


    }


}
