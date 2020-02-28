using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<TModel>
    {
        Task<bool> Create(TModel entity);
        Task Update(TModel entity);
        Task Delete(TModel entity);

        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(Guid id);
    }
}