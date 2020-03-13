using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAirplaneSubTypeRepository : IBaseRepository<AirplaneSubTypeEntity>
    {
        Task<AirplaneSubTypeEntity> GetBy(string name);
    }
}