using StockWeb.Data.Entity;
using System.Collections.Generic;

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
