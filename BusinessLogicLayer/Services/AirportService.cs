using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AirportService : IAirportService
    {
        private IAirportRepository Airport { get; }

        public AirportService(IAirportRepository airport)
        {
            Airport = airport;
        }

        public async Task<bool> Create(Airport entity)
        {
            var airports = await Airport.GetAirportByCountryId(entity.CountryId);
            var isExist = airports.FirstOrDefault(airport =>
                airport.Id == entity.Id
                && airport.Name == entity.Name) != null;

            if (isExist)
            {
                return false;
            }
            await Airport.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(Airport entity)
        {
            var airport = await Airport.GetById(entity.Id);
            if (airport != null)
            {
                await Airport.Update(entity.ToEntity());
            }
        }

        public async Task Delete(Airport entity)
        {
            var airport = await Airport.GetById(entity.Id);
            if (airport != null)
            {
                await Airport.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<Airport>> GetAll() =>
            (await Airport.GetAll())
            .Select(airport => airport.ToModel());

        public async Task<Airport> GetById(Guid id) =>
            (await Airport.GetById(id)).ToModel();
    }
}
