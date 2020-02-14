using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfigurationFactory _configuration;

        public UserRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public void Create(User entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.ExecuteScalar("INSERT INTO " +
                       "Users (Id, FirstName, LastName, Login, Password) " +
                       "VALUES (@Id, @FirstName, @LastName, @Login, @Password)", entity);
        }

        public User GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { id });
        }

        public IEnumerable<User> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.Query<User>("SELECT * FROM Users");
        }

        public void Update(User entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("UPDATE Users SET " +
                       "FirstName = @FirstName, " +
                       "LastName = @LastName, " +
                       "Login = @Login, " +
                       "Password = @Password " +
                       "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("DELETE FROM Users WHERE Id = @Id", new { id });
        }

        public User GetByName(string name)
        {
            using IDbConnection db = _configuration.GetConnection(); 
            return db.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE FirstName = @Name", new { name });
        }

        public async Task<User> GetByNameAsync(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<User>("SELECT * FROM Users WHERE FirstName = @Name",new { name });
        }
    }
}
