using System;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IAirportRepository: IBaseRepository<Airport>
    {
        void AssignCountry(Guid airportId, Guid countryId);
    }
}