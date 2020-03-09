using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IFlightRepository : IBaseRepository<FlightEntity>
    {
        Task<IEnumerable<FlightEntity>> GetBy(
            Guid? airplaneId = null, 
            Guid? destinationAirportId = null, 
            Guid? departureAirportId = null,
            DateTime? arrivalTimeUtc = null);
        Task<FlightEntity> GetBy(Guid airplaneId, Guid destinationAirportId, Guid departureAirportId, DateTime arrivalTimeUtc);
    }
}