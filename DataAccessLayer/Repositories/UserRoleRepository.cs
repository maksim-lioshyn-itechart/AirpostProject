using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly IConfigurationFactory _configuration;

        public UserRoleRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public void Create(UserRole entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.ExecuteScalar("INSERT INTO  Roles (Id,Name) VALUES (@Id, @Name)", entity);
        }

        public UserRole GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QuerySingle<UserRole>("SELECT * FROM Roles WHERE Id = @Id", new { id });
        }

        public IEnumerable<UserRole> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.Query<UserRole>("SELECT * FROM Roles");
        }

        public void Update(UserRole entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("UPDATE Roles SET Name = @Name WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("DELETE FROM Roles WHERE Id = @Id", new { id });
        }

        public void AssignUser(Guid userId, Guid roleId)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute($"UPDATE Users SET RoleId = @RoleId WHERE Id = @UserId", new {roleId, userId});
        }

        public void AssignUser(Guid userId, string roleName)
        {
            using IDbConnection db = _configuration.GetConnection();
            var role = db.QuerySingle<UserRole>($"SELECT * FROM Roles WHERE Name = '{roleName}'", new { roleName });
            AssignUser(userId, role.Id);
        }

        public UserRole GetByName(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QuerySingle<UserRole>($"SELECT * FROM Roles WHERE Name = @Name", new { name });
        }
    }
}
