using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirplaneRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplane", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneEntity>("GetAirplaneById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneEntity>("GetAllAirplanes", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplane", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplane", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneEntity>> GetBy(
            string serialNumber = null,
            string name = null, 
            Guid? airlineId = null, 
            Guid? airplaneSchemaId = null, 
            Guid? airplaneSubTypeId = null, 
            Guid? airplaneTypeId = null
            )
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneEntity>("GetAirplaneBy", 
                new { name, airlineId, airplaneSchemaId, airplaneSubTypeId, airplaneTypeId }, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneEntity> GetBy(string serialNumber)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirplaneEntity>("GetAirplaneBy", new { serialNumber }, commandType: CommandType.StoredProcedure);
        }
    }
}
