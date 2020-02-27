using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PassengerSeatRepository : IPassengerSeatRepository
    {
        private readonly IConfigurationFactory _configuration;

        public PassengerSeatRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(PassengerSeatEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertPassengerSeat", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<PassengerSeatEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<PassengerSeatEntity>("GetPassengerSeatById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PassengerSeatEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<PassengerSeatEntity>("GetAllPassengerSeats", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(PassengerSeatEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdatePassengerSeat", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeletePassengerSeat", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PassengerSeatEntity>> GetBy(Guid airplaneSchemaId)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<PassengerSeatEntity>("GetPassengerSeatsByAirplaneSchemaId", new { airplaneSchemaId }, commandType: CommandType.StoredProcedure);
        }
    }
}
