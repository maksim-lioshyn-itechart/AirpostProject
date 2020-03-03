using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;
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

        public async Task<StatusCode> Create(Airline entity)
        {
            var airlineEntity = (await Airline.GetBy(entity.CountryId))
                .FirstOrDefault(airline => airline.Email == entity.Email);

            var isExist = airlineEntity != null;
            
            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await Airline.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Airline entity)
        {
            var airline = await Airline.GetById(entity.Id);
            if (airline != null)
            {
                await Airline.Update(entity.ToEntity());
                return StatusCode.Updated;
            }

            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Airline entity)
        {
            var airline = await Airline.GetById(entity.Id);
            if (airline != null)
            {
                await Airline.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Airline>> GetAll() =>
            (await Airline.GetAll())
            .Select(airline => airline.ToModel());

        public async Task<Airline> GetById(Guid id) =>
            (await Airline.GetById(id))?.ToModel();
    }
}
