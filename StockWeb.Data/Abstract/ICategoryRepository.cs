using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

namespace StockWeb.Data.Abstract
{
    public interface ICategoryRepository: IRepository<Categories>
    {
    }
}
