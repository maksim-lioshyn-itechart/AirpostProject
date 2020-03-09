using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Enums;

namespace BusinessLogic.Services
{
    public class FlightService : IFlightService
    {
        private IFlightRepository Flight { get; }

        public FlightService(IFlightRepository flight)
        {
            Flight = flight;
        }

        public async Task<StatusCode> Create(Flight entity)
        {
            var flights = await Flight.GetBy(
                entity.AirplaneId,
                entity.DestinationAirportId,
                entity.DepartureAirportId,
                TruncateSeconds(entity.ArrivalTimeUtc));
            var isExist = flights != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            entity.ArrivalTimeUtc = TruncateSeconds(entity.ArrivalTimeUtc);
            entity.DepartureTimeUtc = TruncateSeconds(entity.DepartureTimeUtc);

            await Flight.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Flight entity)
        {
            var flight = await Flight.GetById(entity.Id);
            if (flight != null)
            {
                await Flight.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Flight entity)
        {
            var flight = await Flight.GetById(entity.Id);
            if (flight != null)
            {
                await Flight.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Flight>> GetAll() =>
            (await Flight.GetAll()).Select(flight => flight.ToModel());

        public async Task<Flight> GetById(Guid id) =>
            (await Flight.GetById(id))?.ToModel();

        private DateTime TruncateSeconds(DateTime date) =>
            new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
    }
}
