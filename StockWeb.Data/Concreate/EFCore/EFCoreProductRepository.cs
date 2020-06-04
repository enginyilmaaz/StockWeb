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
    }
}
