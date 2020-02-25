using DataAccessLayer.Models;
using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        void AssignUser(Guid userId, Guid roleId);
    }
}