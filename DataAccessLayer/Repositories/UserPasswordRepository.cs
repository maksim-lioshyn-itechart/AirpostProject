using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserPasswordRepository : IUserPasswordRepository
    {
        private readonly IConfigurationFactory _configuration;

        public UserPasswordRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(UserPasswordEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertUserPassword", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserPasswordEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<UserPasswordEntity>("GetUserPasswordById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserPasswordEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<UserPasswordEntity>("GetAllUserPasswords", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(UserPasswordEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateUserPassword", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteUserPassword", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserPasswordEntity> GetBy(Guid userId)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<UserPasswordEntity>("GetUserPasswordBy", new { userId }, commandType: CommandType.StoredProcedure);
        }
    }
}
