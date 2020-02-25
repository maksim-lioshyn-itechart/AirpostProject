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
        private IUnitOfWork UnitOfWork { get; }

        public PassengerSeatService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(PassengerSeatBm entity)
        {
            var passengerSeats = await UnitOfWork.PassengerSeat.GetPassengerSeatsByAirplaneSchemaId(entity.AirplaneSchemaId);
            var isExist = passengerSeats.FirstOrDefault(seat =>
                              seat.Id == entity.Id
                              && seat.ClassTypeId == entity.ClassTypeId
                              && seat.Sector == entity.Sector
                              && seat.Floor == entity.Floor
                              && seat.Row == entity.Row
                              && seat.Seat == entity.Seat
                              && seat.CoordinateX1 == entity.CoordinateX1
                              && seat.CoordinateY1 == entity.CoordinateY1
                              && seat.CoordinateX2 == entity.CoordinateX2
                              && seat.CoordinateY2 == entity.CoordinateY2) != null;
            if (isExist)
            {
                return false;
            }
            await UnitOfWork.PassengerSeat.Create(entity.ToDal());
            return true;
        }

        public async Task Update(PassengerSeatBm entity)
        {
            var airplanes = await UnitOfWork.PassengerSeat.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.PassengerSeat.Update(entity.ToDal());
            }
        }

        public async Task Delete(PassengerSeatBm entity)
        {
            var airplanes = await UnitOfWork.PassengerSeat.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.PassengerSeat.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<PassengerSeatBm>> GetAll() =>
            (await UnitOfWork.PassengerSeat.GetAll())
            .Select(a => a.ToBm());

        public async Task<PassengerSeatBm> GetById(Guid id) =>
            (await UnitOfWork.PassengerSeat.GetById(id)).ToBm();
    }
}
