using DataAccess.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRoleEntity>
    {
        void AssignUser(Guid userId, Guid roleId);
        Task<UserRoleEntity> GetBy(string name);
    }
}