using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAirportRepository : IBaseRepository<AirportEntity>
    {
        Task<IEnumerable<AirportEntity>> GetBy(Guid? countryId = null, string name = null);
        Task<AirportEntity> GetBy(Guid countryId, string name);
    }
}