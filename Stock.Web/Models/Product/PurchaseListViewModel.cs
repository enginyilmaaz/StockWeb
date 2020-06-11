using StockWeb.Data.Entity;
using System.Collections.Generic;

namespace Stock.Web.Models.Product
{
    public class PurchaseListViewModel
    {
        public List<Purchases> Purchases { get; set; }
    }
}
