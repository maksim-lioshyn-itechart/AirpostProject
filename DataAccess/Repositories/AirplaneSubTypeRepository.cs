using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AirplaneSubTypeRepository : IAirplaneSubTypeRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirplaneSubTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneSubTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplaneSubType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneSubTypeEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneSubTypeEntity>("GetAirplaneSubTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneSubTypeEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneSubTypeEntity>("GetAllAirplaneSubTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneSubTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplaneSubType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplaneSubType", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneSubTypeEntity> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneSubTypeEntity>("GetAllAirplaneSubTypesBy", new { name }, commandType: CommandType.StoredProcedure);
        }
    }
}
