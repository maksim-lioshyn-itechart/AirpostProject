using System;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirportRepository: IBaseRepository<Airport>
    {
        void AssignPlace(Guid airportId, Guid placeId);
    }
}