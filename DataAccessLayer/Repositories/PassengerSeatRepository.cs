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
        public async Task Create(PassengerSeat entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertPassengerSeat", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<PassengerSeat> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<PassengerSeat>("GetPassengerSeatById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PassengerSeat>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<PassengerSeat>("GetAllPassengerSeats", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(PassengerSeat entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdatePassengerSeat", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeletePassengerSeat", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
