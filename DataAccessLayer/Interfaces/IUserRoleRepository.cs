using System;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRoleRepository: IBaseRepository<UserRole>
    {
        void AssignUser(Guid userId, Guid roleId);
        void AssignUser(Guid userId, string roleName);
    }
}