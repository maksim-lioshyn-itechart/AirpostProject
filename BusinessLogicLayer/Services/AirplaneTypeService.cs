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
    public class AirplaneTypeService : IAirplaneTypeService
    {
        private IUnitOfWork UnitOfWork { get; }

        public AirplaneTypeService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<bool> Create(AirplaneTypeBm entity)
        {
            var airplanes = await UnitOfWork.AirplaneType.GetAll();
            if (airplanes.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.AirplaneType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirplaneTypeBm entity)
        {
            var airplanes = await UnitOfWork.AirplaneType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirplaneType.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirplaneTypeBm entity)
        {
            var airplanes = await UnitOfWork.AirplaneType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.AirplaneType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneTypeBm>> GetAll() => 
            (await UnitOfWork.AirplaneType.GetAll())
            .Select(a => a.ToBm());

        public async Task<AirplaneTypeBm> GetById(Guid id) => 
            (await UnitOfWork.AirplaneType.GetById(id)).ToBm();
    }
}
