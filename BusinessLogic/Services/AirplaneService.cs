using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
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
            Validation(entity);
            var airplanes = await Airplane.GetBy(entity.SerialNumber);
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
                Validation(entity);
                await Airplane.Update(entity.ToEntity());
                return StatusCode.Updated;
            }



            if (entity.CarryingCapacity <= 0)
            {
                return StatusCode.IncorrectData;
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

        private void Validation(Airplane entity)
        {
            var validator = new Validator<Airplane>();
            validator.IsValidName(entity.Name);
        }
    }
}
