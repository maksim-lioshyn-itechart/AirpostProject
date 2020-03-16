using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrderStatusRepository : IBaseRepository<OrderStatusEntity>
    {
        Task<OrderStatusEntity> GetBy(string name);
    }
}
