using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

namespace Stock.Web.Models.Category
{
    public class CategoryListViewModel
    {
        public List<Categories> Categories { get; set; }
    }
}
