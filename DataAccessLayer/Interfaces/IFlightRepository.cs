using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetFlightByAirplaneId(Guid airplaneId);
    }
}