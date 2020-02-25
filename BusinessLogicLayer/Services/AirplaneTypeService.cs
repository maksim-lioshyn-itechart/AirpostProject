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
            var types = await UnitOfWork.AirplaneType.GetAll();
            if (types.FirstOrDefault(type => type.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.AirplaneType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(AirplaneTypeBm entity)
        {
            var type = await UnitOfWork.AirplaneType.GetById(entity.Id);
            if (type != null)
            {
                await UnitOfWork.AirplaneType.Update(entity.ToDal());
            }
        }

        public async Task Delete(AirplaneTypeBm entity)
        {
            var type = await UnitOfWork.AirplaneType.GetById(entity.Id);
            if (type != null)
            {
                await UnitOfWork.AirplaneType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneTypeBm>> GetAll() =>
            (await UnitOfWork.AirplaneType.GetAll())
            .Select(type => type.ToBm());

        public async Task<AirplaneTypeBm> GetById(Guid id) =>
            (await UnitOfWork.AirplaneType.GetById(id)).ToBm();
    }
}
