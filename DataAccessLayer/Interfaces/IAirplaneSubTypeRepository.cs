using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneSubTypeRepository : IBaseRepository<AirplaneSubTypeEntity>
    {
        Task<IEnumerable<AirplaneSubTypeEntity>> GetBy(string name);
    }
}