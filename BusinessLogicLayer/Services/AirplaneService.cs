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
    public class AirplaneService : IAirplaneService
    {
        private IAirplaneRepository Airplane { get; }

        public AirplaneService(IAirplaneRepository airplane)
        {
            Airplane = airplane;
        }

        public async Task<bool> Create(Airplane entity)
        {
            var airplanes = 
                (await Airplane.GetAirplanesByAirlineId(entity.AirlineId))
                .FirstOrDefault(
                    airplane =>
                        airplane.Id == entity.Id
                        && airplane.AirplaneSchemaId == entity.AirplaneSchemaId
                        && airplane.AirplaneSubTypeId == entity.AirplaneSubTypeId
                        && airplane.AirplaneTypeId == entity.AirplaneTypeId
                        && airplane.Name == entity.Name);
            var isExist = airplanes != null;

            if (isExist || entity.CarryingCapacity <= 0)
            {
                return false;
            }

            await Airplane.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(Airplane entity)
        {
            var airplane = await Airplane.GetById(entity.Id);
            if (airplane != null && entity.CarryingCapacity > 0)
            {
                await Airplane.Update(entity.ToEntity());
            }
        }

        public async Task Delete(Airplane entity)
        {
            var airplane = await Airplane.GetById(entity.Id);
            if (airplane != null)
            {
                await Airplane.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<Airplane>> GetAll() =>
            (await Airplane.GetAll())
            .Select(airplane => airplane.ToModel());

        public async Task<Airplane> GetById(Guid id) =>
            (await Airplane.GetById(id))?.ToModel();
    }
}
