﻿using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;

namespace BusinessLogicLayer.Services
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
            var flights = (await Flight.GetFlightByAirplaneId(entity.AirplaneId))
                          .FirstOrDefault(
                              flight =>
                                  flight.Id == entity.Id
                                  && flight.DestinationAirportId == entity.DestinationAirportId
                                  && flight.DepartureAirportId == entity.DepartureAirportId
                                  && flight.ArrivalTimeUtc == entity.ArrivalTimeUtc);
            var isExist = flights != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            entity.ArrivalTimeUtc = ConvertToDateTime(entity.ArrivalTimeUtc);
            entity.DepartureTimeUtc = ConvertToDateTime(entity.DepartureTimeUtc);

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

        private DateTime ConvertToDateTime(DateTime date) =>
            new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
    }
}
