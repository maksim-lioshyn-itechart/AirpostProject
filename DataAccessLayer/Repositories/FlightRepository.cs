using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IConfigurationFactory _configuration;
        public FlightRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(Flight entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertFlight", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Flight> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Flight>("GetByIdFlight", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Flight>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Flight>("GetAllFlight", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Flight entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateFlight", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteFlight", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
