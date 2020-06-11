using Microsoft.EntityFrameworkCore;
using StockWeb.Data.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace StockWeb.Data.Concreate.EFCore
{
    public class EFCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
   where TEntity : class
    where TContext : DbContext, new()
    {
        public async void Create(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();

            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);

            }


        }

        public async void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }















    }


}
