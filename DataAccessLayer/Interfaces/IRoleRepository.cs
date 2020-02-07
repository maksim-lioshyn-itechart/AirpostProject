using System;
using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleRepository: IBaseRepository<Role>
    {
        void AssignRoleToUser(Guid idUser, Guid idRole);
        void AssignRoleToUser(Guid idUser, string roleName);
        Role GetByName(string name);
    }
}