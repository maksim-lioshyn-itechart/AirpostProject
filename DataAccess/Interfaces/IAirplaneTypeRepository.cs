using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAirplaneTypeRepository : IBaseRepository<AirplaneTypeEntity>
    {
        Task<AirplaneTypeEntity> GetBy(string name);
    }
}