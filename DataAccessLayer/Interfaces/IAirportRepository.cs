using System;
using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirportRepository: IBaseRepository<Airport>
    {
        void AssignAirportToCountry(Guid idAirport, Guid idCountry);
    }
}