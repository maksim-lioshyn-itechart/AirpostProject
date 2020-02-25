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
        public async Task Create(UserPassword entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertUserPassword", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserPassword> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<UserPassword>("GetUserPasswordById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserPassword>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<UserPassword>("GetAllUserPasswords", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(UserPassword entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateUserPassword", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteUserPassword", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
