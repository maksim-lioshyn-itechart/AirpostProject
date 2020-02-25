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
        private IUnitOfWork UnitOfWork { get; }

        public AirlineService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(AirlineBm entity)
        {
            var airlines = await UnitOfWork.Airline.GetAirlineByCountryId(entity.CountryId);
            if (airlines.FirstOrDefault(airline => airline.Email == entity.Email) != null)
            {
                return false;
            }
            await UnitOfWork.Airline.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirlineBm entity)
        {
            var airline = await UnitOfWork.Airline.GetById(entity.Id);
            if (airline != null)
            {
                await UnitOfWork.Airline.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirlineBm entity)
        {
            var airline = await UnitOfWork.Airline.GetById(entity.Id);
            if (airline != null)
            {
                await UnitOfWork.Airline.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirlineBm>> GetAll() =>
            (await UnitOfWork.Airline.GetAll())
            .Select(airline => airline.ToBm());

        public async Task<AirlineBm> GetById(Guid id) =>
            (await UnitOfWork.Airline.GetById(id)).ToBm();
    }
}
