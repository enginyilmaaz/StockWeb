using System.Collections.Generic;

namespace StockWeb.Data.Entity
{
    public class Categories
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool isActive { get; set; }

        public List<Products> Products { get; set; }
    }
}
