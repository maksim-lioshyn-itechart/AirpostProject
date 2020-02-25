using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAirlineRepository : IBaseRepository<Airline>
    {
        Task<IEnumerable<Airline>> GetAirlineByCountryId(Guid countryId);
    }
}