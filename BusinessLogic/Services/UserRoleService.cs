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
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleRepository UserRole { get; }

        public UserRoleService(IUserRoleRepository userRole)
        {
            UserRole = userRole;
        }

        public async Task<StatusCode> Create(UserRole entity)
        {
            Validation(entity);
            var roles = await UserRole.GetBy(entity.Name);
            var isExist = roles != null;

            if (isExist)
            {
                return StatusCode.AlreadyExists;
            }

            entity.Id = Guid.NewGuid();
            entity.Name = entity.Name;
            await UserRole.Create(entity.ToEntity());
            return StatusCode.Created;
        }

        public async Task<StatusCode> Update(UserRole entity)
        {
            var role = await UserRole.GetById(entity.Id);
            if (role != null)
            {
                Validation(entity);
                entity.Name = entity.Name;
                await UserRole.Update(entity.ToEntity());
                return StatusCode.Updated;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<StatusCode> Delete(UserRole entity)
        {
            var role = await UserRole.GetById(entity.Id);
            if (role != null)
            {
                await UserRole.Delete(entity.Id);
                return StatusCode.Deleted;
            }
            return StatusCode.DoesNotExist;
        }

        public async Task<IEnumerable<UserRole>> GetAll() =>
            (await UserRole.GetAll())
            .Select(role => role.ToModel());

        public async Task<UserRole> GetById(Guid id) =>
            (await UserRole.GetById(id))?.ToModel();

        private void Validation(UserRole entity)
        {
            var validator = new Validator<UserRole>();
            validator.IsValidName(entity.Name);
        }
    }
}
