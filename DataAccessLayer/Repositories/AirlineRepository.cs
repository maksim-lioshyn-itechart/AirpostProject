using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly IConfigurationFactory _configuration;
        public AirlineRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(Airline entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirline", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Airline> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Airline>("GetAirlineById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Airline>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Airline>("GetAllAirlines", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Airline entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirline", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirline", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Airline>> GetAirlineByCountryId(Guid countryId)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Airline>("GetAirlineByCountryId", new { countryId }, commandType: CommandType.StoredProcedure);
        }
    }
}
