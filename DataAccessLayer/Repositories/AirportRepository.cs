using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly IConfigurationFactory _configuration;
        public AirportRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(Airport entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirport", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Airport> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Airport>("GetAirportById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Airport>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Airport>("GetAllAirports", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Airport entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirport", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirport", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
