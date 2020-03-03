using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.enums;
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

        public async Task<StatusCode> Create(AirplaneSubType entity)
        {
            var subTypes = (await AirplaneSubType.GetAll())
                .FirstOrDefault(subType => subType.Name == entity.Name);
            var isExist = subTypes != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await AirplaneSubType.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(AirplaneSubType entity)
        {
            var subType = await AirplaneSubType.GetById(entity.Id);
            if (subType != null)
            {
                await AirplaneSubType.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(AirplaneSubType entity)
        {
            var subType = await AirplaneSubType.GetById(entity.Id);
            if (subType != null)
            {
                await AirplaneSubType.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<AirplaneSubType>> GetAll() =>
            (await AirplaneSubType.GetAll())
            .Select(subType => subType.ToModel());

        public async Task<AirplaneSubType> GetById(Guid id) =>
            (await AirplaneSubType.GetById(id))?.ToModel();
    }
}
