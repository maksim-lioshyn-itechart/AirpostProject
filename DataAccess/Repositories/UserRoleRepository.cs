﻿using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IConfigurationFactory _configuration;

        public UserRoleRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(UserRoleEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertUserRole", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserRoleEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<UserRoleEntity>("GetUserRoleById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserRoleEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<UserRoleEntity>("GetAllUserRoles", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(UserRoleEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateUserRole", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteUserRole", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserRoleEntity> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<UserRoleEntity>("GetUserRolesBy", new { name }, commandType: CommandType.StoredProcedure);
        }
        public void AssignUser(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }

    }
}
