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
    public class PassengerSeatService : IPassengerSeatService
    {
        private IPassengerSeatRepository PassengerSeat { get; }

        public PassengerSeatService(IPassengerSeatRepository passengerSeat)
        {
            PassengerSeat = passengerSeat;
        }

        public async Task<bool> Create(PassengerSeat entity)
        {
            var passengerSeats = (await PassengerSeat.GetBy(entity.AirplaneSchemaId))
                .FirstOrDefault(
                    seat =>
                        seat.Id == entity.Id
                        && seat.ClassTypeId == entity.ClassTypeId
                        && seat.Sector == entity.Sector
                        && seat.Floor == entity.Floor
                        && seat.Row == entity.Row
                        && seat.Seat == entity.Seat
                        && seat.CoordinateX1 == entity.CoordinateX1
                        && seat.CoordinateY1 == entity.CoordinateY1
                        && seat.CoordinateX2 == entity.CoordinateX2
                        && seat.CoordinateY2 == entity.CoordinateY2);
            var isExist = passengerSeats != null;

            if (isExist)
            {
                return false;
            }

            await PassengerSeat.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(PassengerSeat entity)
        {
            var seat = await PassengerSeat.GetById(entity.Id);
            if (seat != null)
            {
                await PassengerSeat.Update(entity.ToEntity());
            }
        }

        public async Task Delete(PassengerSeat entity)
        {
            var seat = await PassengerSeat.GetById(entity.Id);
            if (seat != null)
            {
                await PassengerSeat.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<PassengerSeat>> GetAll() =>
            (await PassengerSeat.GetAll())
            .Select(seat => seat.ToModel());

        public async Task<PassengerSeat> GetById(Guid id) =>
            (await PassengerSeat.GetById(id))?.ToModel();
    }
}
