using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stock.Web.Models.Product;
using StockWeb.Business.Abstract;
using StockWeb.Data.Entity;

namespace Stock.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
       



        public string Index()
        {
            return "sfsadf";
        }





        [Route("Admin/Products")]
        public IActionResult ListProduct()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAllWithCategories()
            });

        }

   







        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.aa = 5;
            ViewBag.CategoryList = _categoryService.GetAll();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model, IFormFile ImageFile)
        {


           
                

            if (!ModelState.IsValid)
            {
                string _ImageUrl = null;
                if (ImageFile != null)

                {
                 
                    var getExtension = Path.GetExtension(ImageFile.FileName);
                    var fileName = string.Format($"{Guid.NewGuid()}{getExtension}");
                    _ImageUrl = "Uploads\\ProductImages\\" + fileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", _ImageUrl);



                    using (var stream = new FileStream(path, FileMode.Create))
                    {

                        await ImageFile.CopyToAsync(stream);
                    }
                }



                var product = new Products
                {
                    CategoryId = model.CategoryId,
                    Name = model.Name,
                    PurchasePrice = model.PurchasePrice,
                    SellingPrice = model.SellingPrice,
                    Quantity = model.Quantity,
                    ImageUrl = _ImageUrl



                };
                _productService.Create(product);
                return RedirectToAction("ListProduct");
            }

            return View("s");
        }
    }
}
