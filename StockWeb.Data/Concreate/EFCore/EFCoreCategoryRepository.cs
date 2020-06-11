using StockWeb.Data.Abstract;
using StockWeb.Data.Entity;
namespace StockWeb.Data.Concreate.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Categories, APPDBContext>, ICategoryRepository
    {
    }
}
