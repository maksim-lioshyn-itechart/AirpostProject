using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IAirlineRepository : IBaseRepository<AirlineEntity>
    {
        Task<IEnumerable<AirlineEntity>> GetBy(string email = null, Guid? countryId = null);
        Task<AirlineEntity> GetBy(string email, Guid countryId);
    }
}