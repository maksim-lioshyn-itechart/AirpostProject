using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using static BusinessLogicLayer.Mappers.AirlineMapper;

namespace BusinessLogicLayer.Services
{
    public class AirlineService: IAirlineService
    {
        private IUnitOfWork UnitOfWork { get; }

        public AirlineService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<bool> Create(AirlineBM entity)
        {
            var airplanes = UnitOfWork.AirlineRepository.GetByCountryIdAirline(entity.CountryId).Result;
            if (airplanes.FirstOrDefault(a => a.Email == entity.Email) != null)
            {
                return false;
            }
            await UnitOfWork.AirlineRepository.Create(entity.ToAirline());
            return true;
        }

        public async Task Update(AirlineBM entity)
        {
            var airplanes = await UnitOfWork.AirlineRepository.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirlineRepository.Update(entity.ToAirline());
            }
        }

        public async Task Delete(AirlineBM entity)
        {
            var airplanes = await UnitOfWork.AirlineRepository.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirlineRepository.Delete(entity.Id);
            }
        }

        public Task<IEnumerable<Airline>> GetAll() => UnitOfWork.AirlineRepository.GetAll();

        public Task<Airline> GetById(Guid id) => UnitOfWork.AirlineRepository.GetById(id);
    }
}
