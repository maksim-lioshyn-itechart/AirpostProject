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
        private IUnitOfWork UnitOfWork { get; }

        public AirportService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(AirportBm entity)
        {
            var airports = await UnitOfWork.Airport.GetAirportByCountryId(entity.CountryId);
            var isExist = airports.FirstOrDefault(airport =>
                airport.Id == entity.Id
                && airport.Name == entity.Name) != null;

            if (isExist)
            {
                return false;
            }
            await UnitOfWork.Airport.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirportBm entity)
        {
            var airport = await UnitOfWork.Airport.GetById(entity.Id);
            if (airport != null)
            {
                await UnitOfWork.Airport.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirportBm entity)
        {
            var airport = await UnitOfWork.Airport.GetById(entity.Id);
            if (airport != null)
            {
                await UnitOfWork.Airport.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirportBm>> GetAll() =>
            (await UnitOfWork.Airport.GetAll())
            .Select(airport => airport.ToBm());

        public async Task<AirportBm> GetById(Guid id) =>
            (await UnitOfWork.Airport.GetById(id)).ToBm();
    }
}
