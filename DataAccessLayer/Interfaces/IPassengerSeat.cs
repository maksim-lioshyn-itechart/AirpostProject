using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IPassengerSeatRepository : IBaseRepository<PassengerSeat>
    {
        Task<IEnumerable<PassengerSeat>> GetPassengerSeatsByAirplaneSchemaId(Guid airplaneSchemaId);
    }
}