using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IAirplaneRepository : IBaseRepository<AirplaneEntity>
    {
        Task<IEnumerable<AirplaneEntity>> GetBy(string serialNumber, string name, Guid? airlineId, Guid? airplaneSchemaId, Guid? airplaneSubTypeId, Guid? airplaneTypeId);
        Task<AirplaneEntity> GetBy(string serialNumber);
    }
}