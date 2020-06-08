using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

namespace StockWeb.Data.Abstract
{
    public interface IProductRepository: IRepository<Products>
    {
        List<Products> GetAllWithCategories();

        void InsertStock(Purchases entity);
        void RemoveStock(Sellings entity);
        List<Purchases> ListProductPurchases();
        List<Sellings> ListProductSellings();
    }
}
