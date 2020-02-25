using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class FlightService : IFlightService
    {
        private IUnitOfWork UnitOfWork { get; }

        public FlightService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(FlightBm entity)
        {
            var flights = await UnitOfWork.Flight.GetFlightByAirplaneId(entity.AirplaneId);
            var a = flights.ToList();

            var isExist = flights.FirstOrDefault(flight =>
                              flight.Id == entity.Id
                              && flight.DestinationAirportId == entity.DestinationAirportId
                              && flight.DepartureAirportId == entity.DepartureAirportId
                              && flight.ArrivalTimeUtc.ToShortDateString() == entity.ArrivalTimeUtc.ToShortDateString()) != null;

            if (isExist)
            {
                return false;
            }

            await UnitOfWork.Flight.Create(entity.ToDal());
            return true;
        }

        public async Task Update(FlightBm entity)
        {
            var flight = await UnitOfWork.Flight.GetById(entity.Id);
            if (flight != null)
            {
                await UnitOfWork.Flight.Update(entity.ToDal());
            }
        }

        public async Task Delete(FlightBm entity)
        {
            var flight = await UnitOfWork.Flight.GetById(entity.Id);
            if (flight != null)
            {
                await UnitOfWork.Flight.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<FlightBm>> GetAll() =>
            (await UnitOfWork.Flight.GetAll()).Select(flight => flight.ToBm());

        public async Task<FlightBm> GetById(Guid id) =>
            (await UnitOfWork.Flight.GetById(id)).ToBm();
    }
}
