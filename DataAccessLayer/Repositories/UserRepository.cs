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
        public async Task Create(User entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertUser", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<User> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<User>("GetUserById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(User entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateUser", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteUser", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
