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
        private IAirplaneTypeRepository AirplaneType { get; }

        public AirplaneTypeService(IAirplaneTypeRepository airplaneType)
        {
            AirplaneType = airplaneType;
        }

        public async Task<bool> Create(AirplaneType entity)
        {
            var types = (await AirplaneType.GetAll())
                .FirstOrDefault(type => type.Name == entity.Name);
            var isExist = types != null;

            if (isExist)
            {
                return false;
            }

            await AirplaneType.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(AirplaneType entity)
        {
            var type = await AirplaneType.GetById(entity.Id);
            if (type != null)
            {
                await AirplaneType.Update(entity.ToEntity());
            }
        }

        public async Task Delete(AirplaneType entity)
        {
            var type = await AirplaneType.GetById(entity.Id);
            if (type != null)
            {
                await AirplaneType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<AirplaneType>> GetAll() =>
            (await AirplaneType.GetAll())
            .Select(type => type.ToModel());

        public async Task<AirplaneType> GetById(Guid id) =>
            (await AirplaneType.GetById(id))?.ToModel();
    }
}
