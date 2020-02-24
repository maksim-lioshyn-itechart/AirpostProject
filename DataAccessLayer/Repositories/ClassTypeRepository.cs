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
    public class ClassTypeRepository: IClassTypeRepository
    {
        private readonly IConfigurationFactory _configuration;
        public ClassTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(ClassType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertClassType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<ClassType> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<ClassType>("GetClassTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ClassType>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<ClassType>("GetAllClassTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(ClassType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateClassType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteClassType", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
