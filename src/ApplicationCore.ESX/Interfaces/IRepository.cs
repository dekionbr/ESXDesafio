using ApplicationCore.ESX.Entities;
using System.Linq;

namespace ApplicationCore.ESX.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IQueryable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count();
    }
}
