using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAirportRepository : IBaseRepository<Airport>
    {
        Task<IEnumerable<Airport>> GetAirportByCountryId(Guid countryId);
    }
}