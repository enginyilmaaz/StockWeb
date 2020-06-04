using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Data.Entity;

namespace StockWeb.Business.Abstract
{
    public interface ICategoryService
    {
        Categories GetById(int id);

        List<Categories> GetAll();

      
        void Create(Categories entity);

        void Update(Categories entity);

        void Delete(Categories entity);
    }
}
