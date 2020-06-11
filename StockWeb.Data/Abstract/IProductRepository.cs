using StockWeb.Data.Entity;
using System.Collections.Generic;

namespace StockWeb.Data.Abstract
{
    public interface IProductRepository : IRepository<Products>
    {
        List<Products> GetAllWithCategories();

        void InsertStock(Purchases entity);
        void RemoveStock(Sellings entity);
        List<Purchases> ListProductPurchases();
        List<Sellings> ListProductSellings();
    }
}
