using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfigurationFactory _configuration;

        public UserRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(UserEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertUser", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<UserEntity>("GetUserById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<UserEntity>("GetAllUsers", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(UserEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateUser", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteUser", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserEntity> GetBy(string email, string phone)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<UserEntity>("GetUserBy", new { email, phone }, commandType: CommandType.StoredProcedure);
        }
    }
}
