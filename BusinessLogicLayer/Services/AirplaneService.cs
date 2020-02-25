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
        private IUnitOfWork UnitOfWork { get; }

        public AirplaneService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(AirplaneBm entity)
        {
            var airplanes = await UnitOfWork.Airplane.GetAirplanesByAirlineId(entity.AirlineId);
            var isExist = airplanes.FirstOrDefault(airplane =>
                airplane.Id == entity.Id
                && airplane.AirplaneSchemaId == entity.AirplaneSchemaId
                && airplane.AirplaneSubTypeId == entity.AirplaneSubTypeId
                && airplane.AirplaneTypeId == entity.AirplaneTypeId
                && airplane.Name == entity.Name) != null;

            if (isExist || entity.CarryingCapacity <= 0)
            {
                return false;
            }
            await UnitOfWork.Airplane.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirplaneBm entity)
        {
            var airplane = await UnitOfWork.Airplane.GetById(entity.Id);
            if (airplane != null && entity.CarryingCapacity > 0)
            {
                await UnitOfWork.Airplane.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirplaneBm entity)
        {
            var airplane = await UnitOfWork.Airplane.GetById(entity.Id);
            if (airplane != null)
            {
                await UnitOfWork.Airplane.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneBm>> GetAll() =>
            (await UnitOfWork.Airplane.GetAll())
            .Select(airplane => airplane.ToBm());

        public async Task<AirplaneBm> GetById(Guid id) =>
            (await UnitOfWork.Airplane.GetById(id)).ToBm();
    }
}
