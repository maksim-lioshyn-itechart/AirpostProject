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
    public class ClassTypeService : IClassTypeService
    {
        private IClassTypeRepository ClassType { get; }

        public ClassTypeService(IClassTypeRepository classType)
        {
            ClassType = classType;
        }

        public async Task<bool> Create(ClassType entity)
        {
            var types = (await ClassType.GetAll())
                .FirstOrDefault(type => type.Name == entity.Name);
            var isExist = types != null;

            if (isExist)
            {
                return false;
            }

            await ClassType.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(ClassType entity)
        {
            var type = await ClassType.GetById(entity.Id);
            if (type != null)
            {
                await ClassType.Update(entity.ToEntity());
            }
        }

        public async Task Delete(ClassType entity)
        {
            var type = await ClassType.GetById(entity.Id);
            if (type != null)
            {
                await ClassType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<ClassType>> GetAll() =>
            (await ClassType.GetAll())
            .Select(type => type.ToModel());

        public async Task<ClassType> GetById(Guid id) =>
            (await ClassType.GetById(id))?.ToModel();
    }
}
