using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Mappers.CommonMapper;

namespace BusinessLogic.Services
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
            Validation(entity);
            var airlineEntity = await Airline.GetBy(entity.Email, entity.CountryId);
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
                Validation(entity);
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

        private void Validation(Airline entity)
        {
            var validator = new Validator<Airline>();
            validator.IsValidName(entity.Name);
            validator.IsValidEmail(entity.Email);
            validator.IsValidPhone(entity.Phone);
        }
    }
}
