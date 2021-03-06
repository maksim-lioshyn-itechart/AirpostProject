﻿using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Mappers.CommonMapper;

namespace BusinessLogic.Services
{
    public class PassengerSeatService : IPassengerSeatService
    {
        private IPassengerSeatRepository PassengerSeat { get; }

        public PassengerSeatService(IPassengerSeatRepository passengerSeat)
        {
            PassengerSeat = passengerSeat;
        }

        public async Task<StatusCode> Create(PassengerSeat entity)
        {
            Validation(entity);
            var passengerSeats = await PassengerSeat.GetById(entity.Id);
            var isExist = passengerSeats != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await PassengerSeat.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(PassengerSeat entity)
        {
            var seat = await PassengerSeat.GetById(entity.Id);
            if (seat != null)
            {
                Validation(entity);
                await PassengerSeat.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(PassengerSeat entity)
        {
            var seat = await PassengerSeat.GetById(entity.Id);
            if (seat != null)
            {
                await PassengerSeat.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<PassengerSeat>> GetAll() =>
            (await PassengerSeat.GetAll())
            .Select(seat => seat.ToModel());

        public async Task<PassengerSeat> GetById(Guid id) =>
            (await PassengerSeat.GetById(id))?.ToModel();

        private void Validation(PassengerSeat entity)
        {
            var validator = new Validator<PassengerSeat>();
        }
    }
}
