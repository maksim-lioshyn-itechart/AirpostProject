﻿using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static DataAccessLayer.Repositories.SpConstants;

namespace DataAccessLayer.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly IConfigurationFactory _configuration;
        public AirplaneRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(Airplane entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync(SpInsertAirports, entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Airplane> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Airplane>(SpSelectByIdAirports, new { id });
        }

        public async Task<IEnumerable<Airplane>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Airplane>(SpSelectAllAirports);
        }

        public async Task Update(Airplane entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync(SpUpdateAirplanes, entity);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync(SpDeleteAirplanes, new { id });
        }
    }
}
