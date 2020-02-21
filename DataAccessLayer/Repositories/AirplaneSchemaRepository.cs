﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class AirplaneSchemaRepository: IAirplaneSchemaRepository
    {
        private readonly IConfigurationFactory _configuration;
        public AirplaneSchemaRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneSchema entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplaneSchema", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneSchema> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<AirplaneSchema>("GetByIdAirplaneSchema", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneSchema>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneSchema>("GetAllAirplaneSchema", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneSchema entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplaneSchema", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplaneSchema", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
