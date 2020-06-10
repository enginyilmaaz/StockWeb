using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stock.Web.Models.Category;
using Stock.Web.Models.Product;
using Stock.Web.Models.Stocks;
using StockWeb.Business.Abstract;
using StockWeb.Business.ToastMessage;
using StockWeb.Data.Entity;
using StockWeb.Data.ToastMessages;

namespace Stock.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
      
        private IProductService _productService;
        private ICategoryService _categoryService;
        private UserManager<Users> _userManager;
        public AdminController(IProductService productService, ICategoryService categoryService, UserManager<Users> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }



        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }


       


        [Route("Admin/Products")]
        public IActionResult ListProduct()
        {
           
            return View(new ProductListViewModel()
            {
            Products = _productService.GetAllWithCategories()
            });

        }


        [Route("Admin/Purchases")]
        public IActionResult ListPurchases()
        {

            return View(new PurchaseListViewModel()
            {
                Purchases =_productService.ListProductPurchases()
            });

        }

        [Route("Admin/Sellings")]
        public IActionResult ListSellings()
        {

            return View(new SellingListViewModel()
            {
                Sellings = _productService.ListProductSellings()
            });

        }





        [Route("Admin/Create/Product")]
        [HttpGet]
        public IActionResult CreateProduct()
        {
           
            ViewBag.CategoryList = _categoryService.GetAll();
            return View();

        }

        [Route("Admin/Create/Product")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model, IFormFile ImageFile)
        {


           
                

            if (ModelState.IsValid)
            {
                string _ImageUrl = null;
                if (ImageFile != null)

                {
                 
                    var getExtension = Path.GetExtension(ImageFile.FileName);
                    var fileName = string.Format($"{Guid.NewGuid()}{getExtension}");
                    _ImageUrl = "Uploads\\ProductImages\\" + fileName;
                  
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", _ImageUrl);
                    Directory.CreateDirectory(Path.GetDirectoryName(path));


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
                    Quantity = 0,
                    ImageUrl = _ImageUrl



                };
                _productService.Create(product);
                ToastMessageSender.ShowMessage(this, "success", AdminMessages.CreateProductSuccess);
                return RedirectToAction("ListProduct");
            }

            return RedirectToAction("ErrorOccured","Home");
        }


        [Route("Admin/Categories")]
        public IActionResult ListCategory()
        {

            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [Route("Admin/Create/Category")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
          
           
            return View();

        }

        [Route("Admin/Create/Category")]
        [HttpPost]
        public  IActionResult CreateCategory(CreateCategoryViewModel model)
        {





            if (ModelState.IsValid)
            {
                var category= new Categories
                {
                   CategoryName = model.CategoryName,
                   isActive = true



                }; 
                _categoryService.Create(category);

                ToastMessageSender.ShowMessage(this, "success", AdminMessages.CreateCategorySuccess);
                return RedirectToAction("ListCategory");
            }

            return RedirectToAction("ErrorOccured", "Home");
        }

        [Route("Admin/Category/Delete/{id?}")]
        public IActionResult DeleteCategory(int id)
        {
            var entity = _categoryService.GetById(id);

            if (entity != null)
            {
               _categoryService.Delete(entity);
            }

            ToastMessageSender.ShowMessage(this, "success", AdminMessages.DeleteCategorySuccess);
            return RedirectToAction("ListCategory");
        }




        [Route("Admin/Product/Delete/{id?}")]
        public IActionResult DeleteProduct(int id)
        {
            var entity = _productService.GetById(id);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            ToastMessageSender.ShowMessage(this, "success", AdminMessages.DeleteProductSuccess);
            return RedirectToAction("ListProduct");
        }



        [Route("Admin/Stock/Insert")]
        [HttpGet]
        public IActionResult InsertStock()
        {
            ViewBag.ProductList = _productService.GetAll();
            return View();
        }


        [Route("Admin/Stock/Insert")]
        [HttpPost]
        public IActionResult InsertStock(StockViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var product = _productService.GetById(model.ProductId);
                product.Quantity += model.Quantity;
                Console.WriteLine(product.Id);
                var purchase = new Purchases
                {
                    OperationTime = DateTime.Now,
                    UserId = userId,
                    isActive = true,
                    Quantity = model.Quantity,
                    PiecePrice = model.PiecePrice,
                    TotalPrice = model.TotalPrice,
                    ProductId = model.ProductId
                    


                };
                _productService.InsertStock(purchase);

                _productService.Update(product);

                ToastMessageSender.ShowMessage(this, "success", AdminMessages.InsertStockSuccess);
                return RedirectToAction("ListProduct");
            
            }

            return RedirectToAction("ErrorOccured", "Home");


        }




        [Route("Admin/Stock/Remove")]
        [HttpGet]
        public IActionResult RemoveStock()
        {
            ViewBag.ProductList = _productService.GetAll();
            return View();
        }


        [Route("Admin/Stock/Remove")]
        [HttpPost]
        public IActionResult RemoveStock(StockViewModel model)
        {


            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var product = _productService.GetById(model.ProductId);
                product.Quantity -= model.Quantity;
                Console.WriteLine(product.Id);
                var selling = new Sellings()
                {
                    OperationTime = DateTime.Now,
                    UserId = userId,
                    isActive = true,
                    Quantity = model.Quantity,
                    PiecePrice = model.PiecePrice,
                    TotalPrice = model.TotalPrice,
                    ProductId = model.ProductId



                };
                _productService.RemoveStock(selling);

                _productService.Update(product);
                ToastMessageSender.ShowMessage(this, "success", AdminMessages.RemoveStockSuccess);
                return RedirectToAction("ListProduct");
            }

            return RedirectToAction("ErrorOccured", "Home");



        }


        [Route("Admin/Category/Edit/{id?}")]
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            var entity = _categoryService.GetById((int)id);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            var model = new EditCategoryViewModel()
            {
               Id = entity.Id,
               CategoryName = entity.CategoryName

            };

            ViewBag.CategoryList = _categoryService.GetAll();

            return View(model);
        }
        [Route("Admin/Category/Edit/{id?}")]
        [HttpPost]
        public IActionResult CategoryEdit(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.CategoryName = model.CategoryName;
            
        
             _categoryService.Update(entity);

             ToastMessageSender.ShowMessage(this, "success", AdminMessages.UpdateCategorySuccess);
                return RedirectToAction("ListCategory");


            }

            return RedirectToAction("ErrorOccured", "Home");
        }



        [Route("Admin/Product/Edit/{id?}")]
        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            var entity = _productService.GetById((int)id);

            if (entity == null)
            {
                return RedirectToAction("ErrorOccured", "Home");
            }

            var model = new EditProductViewModel()
            {
                ProductId = entity.Id,
                Name = entity.Name,
                ImageUrl = entity.ImageUrl,
               
              
                SellingPrice = entity.SellingPrice,
                PurchasePrice = entity.PurchasePrice,
                CategoryId = entity.CategoryId
               
            };

            ViewBag.CategoryList = _categoryService.GetAll();

            return View(model);
        }



        [Route("Admin/Product/Edit/{id?}")]
        [HttpPost]
        public async Task<IActionResult> ProductEdit(EditProductViewModel model,  IFormFile ImageFile)
        {
            
                var entity = _productService.GetById(model.ProductId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.PurchasePrice = model.PurchasePrice;
               
                entity.CategoryId = model.CategoryId;
                entity.SellingPrice = model.SellingPrice;
            if (ImageFile != null)

                {

                    var getExtension = Path.GetExtension(ImageFile.FileName);
                    var fileName = string.Format($"{Guid.NewGuid()}{getExtension}");
                string _ImageUrl = "Uploads\\ProductImages\\" + fileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _ImageUrl);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                entity.ImageUrl = _ImageUrl;

                using (var stream = new FileStream(path, FileMode.Create))
                    {

                        await ImageFile.CopyToAsync(stream);
                    }
                }
            else { entity.ImageUrl = model.ImageUrl; }

                
                        _productService.Update(entity);


            ToastMessageSender.ShowMessage(this, "success", AdminMessages.UpdateProductSuccess);
            return RedirectToAction("ListProduct");


            
            
        }





    }
}
