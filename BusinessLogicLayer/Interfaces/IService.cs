using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<TBM>
    {
        Task<bool> Create(TBM entity);
        Task Update(TBM entity);
        Task Delete(TBM entity);

        Task<IEnumerable<TBM>> GetAll();
        Task<TBM> GetById(Guid id);
    }
}