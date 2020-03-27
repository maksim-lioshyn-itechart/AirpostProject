using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAirplaneSubTypeRepository : IBaseRepository<AirplaneSubTypeEntity>
    {
        Task<AirplaneSubTypeEntity> GetBy(string name);
    }
}