using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IFlightRepository : IBaseRepository<FlightEntity>
    {
        Task<IEnumerable<FlightEntity>> GetBy(Guid airplaneId);
    }
}