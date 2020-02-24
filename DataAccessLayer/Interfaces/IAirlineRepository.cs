using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirlineRepository: IBaseRepository<Airline>
    {
        Task<IEnumerable<Airline>> GetAirlineByCountryId(Guid countryId);
    }
}