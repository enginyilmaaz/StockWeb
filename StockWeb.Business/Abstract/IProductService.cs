using StockWeb.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockWeb.Business.Abstract
{
    public interface IProductService
    {

        Products GetById(int id);

        List<Products> GetAll();

        List<Products> GetAllWithCategories();
        void Create(Products entity);

        void Update(Products entity);

        void Delete(Products entity);

    }
}
