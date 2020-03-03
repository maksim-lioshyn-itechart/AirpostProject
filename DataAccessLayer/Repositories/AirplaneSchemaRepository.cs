using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AirplaneSchemaRepository : IAirplaneSchemaRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirplaneSchemaRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneSchemaEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplaneSchema", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneSchemaEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneSchemaEntity>("GetAirplaneSchemaById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneSchemaEntity>> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneSchemaEntity>("GetAirplaneSchemasBy", new { name }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneSchemaEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneSchemaEntity>("GetAllAirplaneSchemas", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneSchemaEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplaneSchema", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplaneSchema", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
