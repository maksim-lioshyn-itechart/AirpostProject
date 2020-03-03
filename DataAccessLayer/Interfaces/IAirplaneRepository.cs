using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAirplaneRepository : IBaseRepository<AirplaneEntity>
    {
        Task<IEnumerable<AirplaneEntity>> GetBy(string name, Guid? airlineId, Guid? airplaneSchemaId, Guid? airplaneSubTypeId, Guid? airplaneTypeId);
    }
}