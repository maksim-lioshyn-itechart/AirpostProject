using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAirportRepository : IBaseRepository<AirportEntity>
    {
        Task<IEnumerable<AirportEntity>> GetBy(Guid countryId);
    }
}