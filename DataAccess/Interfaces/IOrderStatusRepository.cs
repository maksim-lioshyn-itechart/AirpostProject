using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IOrderStatusRepository : IBaseRepository<OrderStatusEntity>
    {
        Task<OrderStatusEntity> GetBy(string name);
    }
}
