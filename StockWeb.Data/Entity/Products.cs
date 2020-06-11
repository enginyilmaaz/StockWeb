using System.Collections.Generic;

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


        public List<Sellings> Sellings { get; set; }
        public List<Purchases> Purchases { get; set; }

    }
}
