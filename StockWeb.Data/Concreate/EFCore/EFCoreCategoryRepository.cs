using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Abstract;
using StockWeb.Data.Entity;
namespace StockWeb.Data.Concreate.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Categories,APPDBContext>, ICategoryRepository
    {
    }
}
