using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        public void Create(Role entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.ExecuteScalar("INSERT INTO  Roles (Id,Name) VALUES (@Id, @Name)", entity);
        }

        public Role GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Role>("SELECT * FROM Roles WHERE Id = @Id", new { id });
        }

        public IEnumerable<Role> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<Role>("SELECT * FROM Roles");
        }

        public void Update(Role entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("UPDATE Roles SET Name = @Name WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM Roles WHERE Id = @Id", new { id });
        }

        public void AssignUser(Guid userId, Guid roleId)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute($"UPDATE Users SET RoleId = @RoleId WHERE Id = @UserId", new {roleId, userId});
        }

        public void AssignUser(Guid userId, string roleName)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            var role = db.QuerySingle<Role>($"SELECT * FROM Roles WHERE Name = '{roleName}'", new { roleName });
            AssignUser(userId, role.Id);
        }

        public Role GetByName(string name)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Role>($"SELECT * FROM Roles WHERE Name = @Name", new { name });
        }
    }
}
