using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ClassTypeRepository : IClassTypeRepository
    {
        private readonly IConfigurationFactory _configuration;

        public ClassTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(ClassTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertClassType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<ClassTypeEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<ClassTypeEntity>("GetClassTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ClassTypeEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<ClassTypeEntity>("GetAllClassTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(ClassTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateClassType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteClassType", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<ClassTypeEntity> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<ClassTypeEntity>("GetClassTypeBy", new { name }, commandType: CommandType.StoredProcedure);
        }
    }
}
