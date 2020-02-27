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
        private IAirplaneSubTypeRepository AirplaneSubType { get; }

        public AirplaneSubTypeService(IAirplaneSubTypeRepository airplaneSubType)
        {
            AirplaneSubType = airplaneSubType;
        }

        public async Task<bool> Create(AirplaneSubType entity)
        {
            var subTypes = (await AirplaneSubType.GetAll())
                .FirstOrDefault(subType => subType.Name == entity.Name);
            var isExist = subTypes != null;

            if (isExist)
            {
                return false;
            }

            await AirplaneSubType.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(AirplaneSubType entity)
        {
            var subType = await AirplaneSubType.GetById(entity.Id);
            if (subType != null)
            {
                await AirplaneSubType.Update(entity.ToEntity());
            }
        }

        public async Task Delete(AirplaneSubType entity)
        {
            var subType = await AirplaneSubType.GetById(entity.Id);
            if (subType != null)
            {
                await AirplaneSubType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneSubType>> GetAll() =>
            (await AirplaneSubType.GetAll())
            .Select(subType => subType.ToModel());

        public async Task<AirplaneSubType> GetById(Guid id) =>
            (await AirplaneSubType.GetById(id))?.ToModel();
    }
}
