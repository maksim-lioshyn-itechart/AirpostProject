using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderStatusRepository : IBaseRepository<OrderStatusEntity>
    {
        Task<IEnumerable<OrderStatusEntity>> GetBy(string name);
    }
}
