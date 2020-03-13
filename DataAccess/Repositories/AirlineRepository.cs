using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirlineRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirlineEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirline", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirlineEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirlineEntity>("GetAirlineById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirlineEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirlineEntity>("GetAllAirlines", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirlineEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirline", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirline", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirlineEntity>> GetBy(string email, Guid? countryId)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirlineEntity>("GetAirlineBy", new { email, countryId }, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirlineEntity> GetBy(string email, Guid countryId)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirlineEntity>("GetAirlineBy", new { email, countryId }, commandType: CommandType.StoredProcedure);
        }
    }
}
