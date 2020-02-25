using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AirplaneSubTypeRepository : IAirplaneSubTypeRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirplaneSubTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneSubType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplaneSubType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneSubType> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneSubType>("GetAirplaneSubTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneSubType>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneSubType>("GetAllAirplaneSubTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneSubType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplaneSubType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplaneSubType", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
