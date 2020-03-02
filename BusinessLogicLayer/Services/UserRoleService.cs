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
        private IUserRoleRepository UserRole { get; }

        public UserRoleService(IUserRoleRepository userRole)
        {
            UserRole = userRole;
        }

        public async Task<bool> Create(UserRole entity)
        {
            var roles = (await UserRole.GetAll())
                .FirstOrDefault(role => role.Name == entity.Name);
            var isExist = roles != null;

            if (isExist)
            {
                return false;
            }

            entity.Id = Guid.NewGuid();
            entity.Name = entity.Name.ToUpper();
            await UserRole.Create(entity.ToEntity());
            return true;
        }

        public async Task Update(UserRole entity)
        {
            var role = await UserRole.GetById(entity.Id);
            if (role != null)
            {
                entity.Name = entity.Name.ToUpper();
                await UserRole.Update(entity.ToEntity());
            }
        }

        public async Task Delete(UserRole entity)
        {
            var role = await UserRole.GetById(entity.Id);
            if (role != null)
            {
                await UserRole.Delete(entity.Id);
            }
        }

        public async Task<IEnumerable<UserRole>> GetAll() =>
            (await UserRole.GetAll())
            .Select(role => role.ToModel());

        public async Task<UserRole> GetById(Guid id) =>
            (await UserRole.GetById(id))?.ToModel();
    }
}
