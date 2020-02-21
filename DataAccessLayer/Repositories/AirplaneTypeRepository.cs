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
    public class AirplaneTypeRepository: IAirplaneTypeRepository
    {
        private readonly IConfigurationFactory _configuration;
        public AirplaneTypeRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(AirplaneType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertAirplaneType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<AirplaneType> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<AirplaneType>("GetByIdAirplaneType", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AirplaneType>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<AirplaneType>("GetAllAirplaneType", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AirplaneType entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplaneType", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplaneType", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}