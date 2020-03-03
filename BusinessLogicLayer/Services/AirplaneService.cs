using BusinessLogicLayer.Interfaces;
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
    public class AirplaneService : IAirplaneService
    {
        private IAirplaneRepository Airplane { get; }

        public AirplaneService(IAirplaneRepository airplane)
        {
            Airplane = airplane;
        }

        public async Task<StatusCode> Create(Airplane entity)
        {
            var airplanes = 
                (await Airplane.GetBy(entity.AirlineId))
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
                return StatusCode.AlreadyExists;
            }

            await Airplane.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(Airplane entity)
        {
            var airplane = await Airplane.GetById(entity.Id);
            if (airplane != null && entity.CarryingCapacity > 0)
            {
                await Airplane.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(Airplane entity)
        {
            var airplane = await Airplane.GetById(entity.Id);
            if (airplane != null)
            {
                await Airplane.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<Airplane>> GetAll() =>
            (await Airplane.GetAll())
            .Select(airplane => airplane.ToModel());

        public async Task<Airplane> GetById(Guid id) =>
            (await Airplane.GetById(id))?.ToModel();
    }
}
