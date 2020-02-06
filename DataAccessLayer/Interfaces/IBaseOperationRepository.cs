using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IBaseOperationRepository<T>
    {
        void Create(T entity);
        T GetById(Guid id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(Guid id);
    }
}