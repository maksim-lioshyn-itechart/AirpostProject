using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly IConfigurationFactory _configuration;
        public UserRoleRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(UserRole entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertUserRole", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserRole> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<UserRole>("GetByIdUserRole", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserRole>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<UserRole>("GetAllUserRole", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(UserRole entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateUserRole", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteUserRole", new { id }, commandType: CommandType.StoredProcedure);
        }

        public void AssignUser(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }
    }
}
