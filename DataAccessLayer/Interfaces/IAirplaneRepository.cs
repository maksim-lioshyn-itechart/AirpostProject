using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneRepository : IBaseRepository<Airplane>
    {
        Task<IEnumerable<Airplane>> GetAirplanesByAirlineId(Guid airlineId);
    }
}