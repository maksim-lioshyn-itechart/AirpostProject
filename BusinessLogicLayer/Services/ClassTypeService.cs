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
        private IUnitOfWork UnitOfWork { get; }

        public ClassTypeService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ClassTypeBm entity)
        {
            var types = await UnitOfWork.ClassType.GetAll();
            if (types.FirstOrDefault(type => type.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.ClassType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(ClassTypeBm entity)
        {
            var type = await UnitOfWork.ClassType.GetById(entity.Id);
            if (type != null)
            {
                await UnitOfWork.ClassType.Update(entity.ToDal());
            }
        }

        public async Task Delete(ClassTypeBm entity)
        {
            var type = await UnitOfWork.ClassType.GetById(entity.Id);
            if (type != null)
            {
                await UnitOfWork.ClassType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<ClassTypeBm>> GetAll() =>
            (await UnitOfWork.ClassType.GetAll())
            .Select(type => type.ToBm());

        public async Task<ClassTypeBm> GetById(Guid id) =>
            (await UnitOfWork.ClassType.GetById(id)).ToBm();
    }
}
