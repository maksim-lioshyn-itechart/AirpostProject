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
    public class CountryRepository: ICountryRepository
    {
        private readonly IConfigurationFactory _configuration;
        public CountryRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(Country entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertCountry", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Country> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Country>("GetCountryById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Country>("GetAllCountries", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Country entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateCountry", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteCountry", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
