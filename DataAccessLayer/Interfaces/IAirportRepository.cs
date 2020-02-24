using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirportRepository: IBaseRepository<Airport>
    {
        Task<IEnumerable<Airport>> GetAirportByCountryId(Guid countryId);
    }
}