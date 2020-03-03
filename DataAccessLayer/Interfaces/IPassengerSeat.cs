using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPassengerSeatRepository : IBaseRepository<PassengerSeatEntity>
    {
        Task<IEnumerable<PassengerSeatEntity>> GetBy(Guid? airplaneSchemaId = null, Guid? classTypeId = null,
            string sector = null,
            int? floor = null,
            int? row = null,
            int? seat = null,
            int? coordinateX1 = null,
            int? coordinateY1 = null,
            int? coordinateX2 = null,
            int? coordinateY2 = null
        );
    }
}