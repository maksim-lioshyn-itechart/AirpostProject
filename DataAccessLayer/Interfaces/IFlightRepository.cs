using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetFlightByAirplaneId(Guid airplaneId);
    }
}