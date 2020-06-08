using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockWeb.Data.Abstract;
using StockWeb.Data.Entity;

namespace StockWeb.Data.Concreate.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Products,APPDBContext>, IProductRepository
    {

        public List<Products> GetAllWithCategories()
        {
            using (var context = new APPDBContext())
            {
                return context.Products.Include(i=>i.Category).
                    ToList();

            }
        }
        public List<Purchases> ListProductPurchases()
        {
            using (var context = new APPDBContext())
            {
                return context.Purchases.Include(i => i.Product)
                    .Include(i => i.User).
                    ToList();

            }
        }

        public List<Sellings> ListProductSellings()
        {
            using (var context = new APPDBContext())
            {
                return context.Sellings.Include(i => i.Product)
                    .Include(i => i.User).
                    ToList();

            }
        }



        public async void InsertStock(Purchases entity)
        {
            using (var context = new APPDBContext())
            {
                context.Purchases.Add(entity);
                await context.SaveChangesAsync();

            }
        }


        public async void RemoveStock(Sellings entity)
        {
            using (var context = new APPDBContext())
            {
                context.Sellings.Add(entity);
                await context.SaveChangesAsync();

            }
        }
    }
}
