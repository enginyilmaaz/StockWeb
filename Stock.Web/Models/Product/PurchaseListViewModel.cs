using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

namespace Stock.Web.Models.Product
{
    public class PurchaseListViewModel
    {
        public List<Purchases> Purchases { get; set; }
    }
}
