using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AirplaneTypeRepository : IAirplaneTypeRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirplaneTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplaneType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneTypeEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneTypeEntity>("GetAirplaneTypeById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneTypeEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneTypeEntity>("GetAllAirplaneTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneTypeEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplaneType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplaneType", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneTypeEntity>> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneTypeEntity>("GetAirplaneTypesBy", new { name }, commandType: CommandType.StoredProcedure);
        }
    }
}
