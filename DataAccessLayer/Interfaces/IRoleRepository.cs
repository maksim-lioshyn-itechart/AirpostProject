using System;
using ORM.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleRepository: IBaseRepository<Role>
    {
        bool AssignRoleToUser(Guid idUser, Guid idRole);
        bool AssignRoleToUser(Guid idUser, string roleName);
        Role GetByName(string name);
    }
}