﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

namespace Stock.Web.Models.Product
{
    public class ProductListViewModel
    {
        public List<Products> Products { get; set; }
    }
}