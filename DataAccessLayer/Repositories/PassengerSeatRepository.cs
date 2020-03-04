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

        public async Task<IEnumerable<PassengerSeatEntity>> GetBy(
            Guid? airplaneSchemaId = null, Guid? classTypeId = null, 
            string sector = null, int? floor = null,
            int? row = null, int? seat = null,
            int? coordinateX1 = null, int? coordinateY1 = null,
            int? coordinateX2 = null, int? coordinateY2 = null
            )
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<PassengerSeatEntity>("GetPassengerSeatsBy",
                new
                {
                    airplaneSchemaId,
                    classTypeId,
                    sector,
                    floor,
                    row,
                    seat,
                    coordinateX1,
                    coordinateY1,
                    coordinateX2,
                    coordinateY2
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<PassengerSeatEntity> GetBy(Guid airplaneSchemaId, Guid classTypeId, string sector, int floor, int row, int seat, int coordinateX1,
            int coordinateY1, int coordinateX2, int coordinateY2)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<PassengerSeatEntity>("GetPassengerSeatsBy",
                new
                {
                    airplaneSchemaId,
                    classTypeId,
                    sector,
                    floor,
                    row,
                    seat,
                    coordinateX1,
                    coordinateY1,
                    coordinateX2,
                    coordinateY2
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
