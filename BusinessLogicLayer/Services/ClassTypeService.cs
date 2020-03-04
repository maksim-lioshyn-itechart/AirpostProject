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
    public class ClassTypeService : IClassTypeService
    {
        private IClassTypeRepository ClassType { get; }

        public ClassTypeService(IClassTypeRepository classType)
        {
            ClassType = classType;
        }

        public async Task<StatusCode> Create(ClassType entity)
        {
            var types = await ClassType.GetBy(entity.Name);
            var isExist = types != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            await ClassType.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(ClassType entity)
        {
            var type = await ClassType.GetById(entity.Id);
            if (type != null)
            {
                await ClassType.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(ClassType entity)
        {
            var type = await ClassType.GetById(entity.Id);
            if (type != null)
            {
                await ClassType.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<ClassType>> GetAll() =>
            (await ClassType.GetAll())
            .Select(type => type.ToModel());

        public async Task<ClassType> GetById(Guid id) =>
            (await ClassType.GetById(id))?.ToModel();
    }
}
