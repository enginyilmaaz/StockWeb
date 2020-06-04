using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockWeb.Data.Entity
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public double PurchasePrice { get; set; }

        public double SellingPrice { get; set; }

        public int Quantity { get; set; }

        public bool isActive { get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; }


    }
}
