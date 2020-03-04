using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneSubTypeRepository : IBaseRepository<AirplaneSubTypeEntity>
    {
        Task<AirplaneSubTypeEntity> GetBy(string name);
    }
}