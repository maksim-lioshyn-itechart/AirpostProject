using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAirplaneTypeRepository : IBaseRepository<AirplaneTypeEntity>
    {
        Task<AirplaneTypeEntity> GetBy(string name);
    }
}