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
    public class AirplaneSubTypeService : IAirplaneSubTypeService
    {
        private IUnitOfWork UnitOfWork { get; }

        public AirplaneSubTypeService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<bool> Create(AirplaneSubTypeBm entity)
        {
            var airplanes = await UnitOfWork.AirplaneSubType.GetAll();
            if (airplanes.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.AirplaneSubType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirplaneSubTypeBm entity)
        {
            var airplanes = await UnitOfWork.AirplaneSubType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirplaneSubType.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirplaneSubTypeBm entity)
        {
            var airplanes = await UnitOfWork.AirplaneSubType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirplaneSubType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneSubTypeBm>> GetAll() => 
            (await UnitOfWork.AirplaneSubType.GetAll())
            .Select(a => a.ToBm());

        public async Task<AirplaneSubTypeBm> GetById(Guid id) => 
            (await UnitOfWork.AirplaneSubType.GetById(id)).ToBm();
    }
}
