using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IReadOnlyList<T> ListAll();
        IReadOnlyList<T> List();
        T AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count();
    }
}
