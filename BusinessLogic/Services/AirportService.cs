﻿using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Enums;
using DataAccess.Interfaces;

namespace BusinessLogic.Services
{
    public class AirportService : IAirportService
    {
        private IAirportRepository Airport { get; }

        public AirportService(IAirportRepository airport)
        {
            Airport = airport;
        }

        public async Task<StatusCode> Create(Airport entity)
        {
            var airports = await Airport.GetBy(entity.CountryId, entity.Name);
            var isExist = airports != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }
            await Airport.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Airport entity)
        {
            var airport = await Airport.GetById(entity.Id);
            if (airport != null)
            {
                await Airport.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Airport entity)
        {
            var airport = await Airport.GetById(entity.Id);
            if (airport != null)
            {
                await Airport.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Airport>> GetAll() =>
            (await Airport.GetAll())
            .Select(airport => airport.ToModel());

        public async Task<Airport> GetById(Guid id) =>
            (await Airport.GetById(id))?.ToModel();
    }
}
