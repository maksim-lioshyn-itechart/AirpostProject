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
            var isExist = flights.FirstOrDefault(flight =>
                              flight.Id == entity.Id
                              && flight.DestinationAirportId == entity.DestinationAirportId
                              && flight.DepartureAirportId == entity.DepartureAirportId
                              && CompareDates(flight.ArrivalTimeUtc, entity.ArrivalTimeUtc)) != null;

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

        public bool CompareDates(DateTime date, DateTime entityDate) =>
            date.ToString("yyyy-mm-dd HH:MM") == entityDate.ToString("yyyy-mm-dd HH:MM");
    }
}
