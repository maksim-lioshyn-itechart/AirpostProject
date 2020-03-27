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
    public class ClassTypeService : IClassTypeService
    {
        private IClassTypeRepository ClassType { get; }

        public ClassTypeService(IClassTypeRepository classType)
        {
            ClassType = classType;
        }

        public async Task<StatusCode> Create(ClassType entity)
        {
            Validation(entity);
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
                Validation(entity);
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

        private void Validation(ClassType entity)
        {
            var validator = new Validator<ClassType>();
            validator.IsValidName(entity.Name);
        }
    }
}
