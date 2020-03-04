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

        public async Task Create(FlightEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertFlight", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<FlightEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<FlightEntity>("GetFlightById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FlightEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<FlightEntity>("GetAllFlights", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(FlightEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateFlight", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteFlight", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FlightEntity>> GetBy(
            Guid? airplaneId = null, 
            Guid? destinationAirportId = null, 
            Guid? departureAirportId = null,
            DateTime? arrivalTimeUtc = null)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<FlightEntity>("GetFlightBy", 
                new { airplaneId, destinationAirportId, departureAirportId, arrivalTimeUtc }, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<FlightEntity> GetBy(Guid airplaneId, Guid destinationAirportId, Guid departureAirportId, DateTime arrivalTimeUtc)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<FlightEntity>("GetFlightBy",
                new { airplaneId, destinationAirportId, departureAirportId, arrivalTimeUtc },
                commandType: CommandType.StoredProcedure);
        }
    }
}
