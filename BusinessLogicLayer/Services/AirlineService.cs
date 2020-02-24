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
    public class AirlineService: IAirlineService
    {
        private IUnitOfWork UnitOfWork { get; }

        public AirlineService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<bool> Create(AirlineBm entity)
        {
            var airplanes = await UnitOfWork.AirlineRepository.GetByCountryIdAirline(entity.CountryId);
            if (airplanes.FirstOrDefault(a => a.Email == entity.Email) != null)
            {
                return false;
            }
            await UnitOfWork.AirlineRepository.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirlineBm entity)
        {
            var airplanes = await UnitOfWork.AirlineRepository.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirlineRepository.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirlineBm entity)
        {
            var airplanes = await UnitOfWork.AirlineRepository.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirlineRepository.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirlineBm>> GetAll() => 
            (await UnitOfWork.AirlineRepository.GetAll())
            .Select(a => a.ToBm());

        public async Task<AirlineBm> GetById(Guid id) => 
            (await UnitOfWork.AirlineRepository.GetById(id)).ToBm();
    }
}
