using System;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleRepository: IBaseRepository<Role>
    {
        void AssignUser(Guid userId, Guid roleId);
        void AssignUser(Guid userId, string roleName);
        Role GetByName(string name);
    }
}