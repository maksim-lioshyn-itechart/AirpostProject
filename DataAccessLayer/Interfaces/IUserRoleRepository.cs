using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRoleEntity>
    {
        void AssignUser(Guid userId, Guid roleId);
    }
}