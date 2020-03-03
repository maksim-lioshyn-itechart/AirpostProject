﻿using Dapper;
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

        public async Task Create(AirportEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirport", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirportEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<AirportEntity>("GetAirportById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirportEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirportEntity>("GetAllAirports", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirportEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirport", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirport", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirportEntity>> GetBy(Guid countryId)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirportEntity>("GetAirportBy", new { countryId }, commandType: CommandType.StoredProcedure);
        }
    }
}
