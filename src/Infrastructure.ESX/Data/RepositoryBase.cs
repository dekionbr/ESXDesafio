using ApplicationCore.ESX.Entities;
using ApplicationCore.ESX.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.ESX.Data
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ESXContext _dbContext;

        public RepositoryBase(ESXContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public int Count()
        {
            return _dbContext.Set<T>().Count();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> ListAll()
        {
            return _dbContext.Set<T>();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

    }
}
