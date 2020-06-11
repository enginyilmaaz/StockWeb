using Microsoft.EntityFrameworkCore;
using StockWeb.Data.Abstract;
using StockWeb.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace StockWeb.Data.Concreate.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Products, APPDBContext>, IProductRepository
    {

        public List<Products> GetAllWithCategories()
        {
            using (APPDBContext context = new APPDBContext())
            {
                return context.Products.Include(i => i.Category).
                    ToList();

            }
        }
        public List<Purchases> ListProductPurchases()
        {
            using (APPDBContext context = new APPDBContext())
            {
                return context.Purchases.Include(i => i.Product)
                    .Include(i => i.User).
                    ToList();

            }
        }

        public List<Sellings> ListProductSellings()
        {
            using (APPDBContext context = new APPDBContext())
            {
                return context.Sellings.Include(i => i.Product)
                    .Include(i => i.User).
                    ToList();

            }
        }



        public async void InsertStock(Purchases entity)
        {
            using (APPDBContext context = new APPDBContext())
            {
                context.Purchases.Add(entity);
                await context.SaveChangesAsync();

            }
        }


        public async void RemoveStock(Sellings entity)
        {
            using (APPDBContext context = new APPDBContext())
            {
                context.Sellings.Add(entity);
                await context.SaveChangesAsync();

            }
        }
    }
}
