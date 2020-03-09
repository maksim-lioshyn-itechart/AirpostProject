using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Delete(Guid id);
    }
}