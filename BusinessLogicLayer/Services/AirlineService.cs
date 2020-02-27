using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogicLayer.Mappers.CommonMapper;

namespace BusinessLogicLayer.Services
{
    public class AirlineService : IAirlineService
    {
        private IAirlineRepository Airline { get; }

        public AirlineService(IAirlineRepository airline)
        {
            Airline = airline;
        }

        public async Task<bool> Create(Airline entity)
        {
            var airlines = await Airline.GetAirlineByCountryId(entity.CountryId);
            if (airlines.FirstOrDefault(airline => airline.Email == entity.Email) != null)
            {
                return false;
            }
            await Airline.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(Airline entity)
        {
            var airline = await Airline.GetById(entity.Id);
            if (airline != null)
            {
                await Airline.Update(entity.ToEntity());
            }
        }

        public async Task Delete(Airline entity)
        {
            var airline = await Airline.GetById(entity.Id);
            if (airline != null)
            {
                await Airline.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<Airline>> GetAll() =>
            (await Airline.GetAll())
            .Select(airline => airline.ToModel());

        public async Task<Airline> GetById(Guid id) =>
            (await Airline.GetById(id)).ToModel();
    }
}
