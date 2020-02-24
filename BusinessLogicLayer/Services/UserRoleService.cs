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
    public class UserRoleService : IUserRoleService
    {
        private IUnitOfWork UnitOfWork { get; }

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<bool> Create(UserRoleBm entity)
        {
            var airplanes = await UnitOfWork.UserRole.GetAll();
            if (airplanes.FirstOrDefault(a => a.Name == entity.Name) != null)
            {
                return false;
            }
            await UnitOfWork.UserRole.Create(entity.ToDal());
            return true;
        }

        public async Task Update(UserRoleBm entity)
        {
            var airplanes = await UnitOfWork.UserRole.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.UserRole.Update(entity.ToDal());
            }
        }

        public async Task Delete(UserRoleBm entity)
        {
            var airplanes = await UnitOfWork.UserRole.GetById(entity.Id);
            if (airplanes != null)
            {
                await UnitOfWork.UserRole.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<UserRoleBm>> GetAll() => 
            (await UnitOfWork.UserRole.GetAll())
            .Select(a => a.ToBm());

        public async Task<UserRoleBm> GetById(Guid id) => 
            (await UnitOfWork.UserRole.GetById(id)).ToBm();
    }
}
