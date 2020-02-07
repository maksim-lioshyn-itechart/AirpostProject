using System;
using DataAccessLayer.Interfaces;
using ORM.Attributes;
using ORM.Models;

namespace DataAccessLayer.Repositories
{
    public class AirportRepository: BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AssignAirportToCountry(Guid idAirport, Guid idCountry)
        {
            var tableName = typeof(Airport).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
            UnitOfWork.Saving($"UPDATE {tableName} SET CountryId = '{idCountry}' WHERE Id = '{idAirport}'");
        }
    }
}
