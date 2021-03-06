﻿using StockWeb.Data.Entity;
using System.Collections.Generic;

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

        void InsertStock(Purchases entity);
        void RemoveStock(Sellings entity);
        List<Purchases> ListProductPurchases();
        List<Sellings> ListProductSellings();
    }
}
