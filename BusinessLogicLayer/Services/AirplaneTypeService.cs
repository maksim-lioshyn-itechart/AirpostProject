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
    public class AirplaneTypeService : IAirplaneTypeService
    {
        private IAirplaneTypeRepository AirplaneType { get; }

        public AirplaneTypeService(IAirplaneTypeRepository airplaneType)
        {
            AirplaneType = airplaneType;
        }

        public async Task<StatusCode> Create(AirplaneType entity)
        {
            var types = await AirplaneType.GetBy(entity.Name);
            var isExist = types != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await AirplaneType.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(AirplaneType entity)
        {
            var type = await AirplaneType.GetById(entity.Id);
            if (type != null)
            {
                await AirplaneType.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(AirplaneType entity)
        {
            var type = await AirplaneType.GetById(entity.Id);
            if (type != null)
            {
                await AirplaneType.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<AirplaneType>> GetAll() =>
            (await AirplaneType.GetAll())
            .Select(type => type.ToModel());

        public async Task<AirplaneType> GetById(Guid id) =>
            (await AirplaneType.GetById(id))?.ToModel();
    }
}
