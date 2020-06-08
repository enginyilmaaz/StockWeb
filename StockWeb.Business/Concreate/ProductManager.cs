using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using StockWeb.Business.Abstract;
using StockWeb.Data.Abstract;
using StockWeb.Data.Concreate.EFCore;
using StockWeb.Data.Entity;

namespace StockWeb.Business.Concreate
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Products entity)
        {
            entity.isActive = true;
          

            _productRepository.Create(entity);
        }

        public void Delete(Products entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Products> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Products GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(Products entity)
        {
            _productRepository.Update(entity);
        }
        public List<Products> GetAllWithCategories()
        {
            return _productRepository.GetAllWithCategories();
        }

        public void InsertStock(Purchases entity)
        {
           
            _productRepository.InsertStock(entity);
        }
        public void RemoveStock(Sellings entity)
        {

            _productRepository.RemoveStock(entity);
        }


        public List<Purchases> ListProductPurchases()
        {

            return _productRepository.ListProductPurchases();
        }


        public List<Sellings> ListProductSellings()
        {

            return _productRepository.ListProductSellings();
        }
    }
}
