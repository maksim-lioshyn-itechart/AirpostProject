using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(Guid id);
    }
}