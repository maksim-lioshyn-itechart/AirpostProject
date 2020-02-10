using Dapper;
using DataAccessLayer.Interfaces;
using ORM.Attributes;
using ORM.Models;
using System;
using System.Data;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository:BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool AssignRoleToUser(Guid idUser, Guid idRole)
        {
            var tableName = typeof(User).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
            UnitOfWork.Saving($"UPDATE {tableName} SET RoleId = '{idRole}' WHERE Id = '{idUser}'");
            return true;
        }

        public bool AssignRoleToUser(Guid idUser, string roleName)
        {
            using IDbConnection db = new ApplicationContext().OpenConnection();
            var role = db.Query<Role>($"SELECT * FROM {TableName()} WHERE Name = '{roleName}'", new { roleName }).FirstOrDefault();
            if (role != null)
            {
                AssignRoleToUser(idUser, role.Id);
                return true;
            }
            return false;
        }

        public Role GetByName(string name)
        {
            var tableName = typeof(Role).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return db.Query<Role>($"SELECT * FROM {tableName} WHERE Name = '{name}'", new { name }).FirstOrDefault();
        }
    }
}
