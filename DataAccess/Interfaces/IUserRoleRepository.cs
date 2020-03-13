using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRoleEntity>
    {
        void AssignUser(Guid userId, Guid roleId);
        Task<UserRoleEntity> GetBy(string name);
    }
}