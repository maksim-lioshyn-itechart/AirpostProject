using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BusinessLogic.Mappers.CommonMapper;

namespace BusinessLogic.Services
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
            Validation(entity);
            var subTypes = await AirplaneSubType.GetBy(entity.Name);
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
                Validation(entity);
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

        private void Validation(AirplaneSubType entity)
        {
            var validator = new Validator<AirplaneSubType>();
            validator.IsValidName(entity.Name);
        }
    }
}
