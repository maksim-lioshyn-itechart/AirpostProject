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
            var airplanes = await UnitOfWork.ClassType.GetAll();
            if (airplanes.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.ClassType.Create(entity.ToDal());
            return true;
        }

        public async Task Update(ClassTypeBm entity)
        {
            var airplanes = await UnitOfWork.ClassType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.ClassType.Update(entity.ToDal());
            }
        }

        public async Task Delete(ClassTypeBm entity)
        {
            var airplanes = await UnitOfWork.ClassType.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.ClassType.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<ClassTypeBm>> GetAll() => 
            (await UnitOfWork.ClassType.GetAll())
            .Select(a => a.ToBm());

        public async Task<ClassTypeBm> GetById(Guid id) => 
            (await UnitOfWork.ClassType.GetById(id)).ToBm();
    }
}
