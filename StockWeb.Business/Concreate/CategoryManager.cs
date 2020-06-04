using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWeb.Business.Abstract;
using StockWeb.Data.Abstract;
using StockWeb.Data.Entity;

namespace StockWeb.Business.Concreate
{
    public class CategoryManager: ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Categories entity)
        {
            entity.isActive = true;


            _categoryRepository.Create(entity);
        }

        public void Delete(Categories entity)
        {
            _categoryRepository.Delete(entity);
        }

        public List<Categories> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Categories GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(Categories entity)
        {
            _categoryRepository.Update(entity);
        }
     

    }
}
