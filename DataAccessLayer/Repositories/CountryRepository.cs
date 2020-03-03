using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IConfigurationFactory _configuration;

        public CountryRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(CountryEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertCountry", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<CountryEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<CountryEntity>("GetCountryById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CountryEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<CountryEntity>("GetAllCountries", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(CountryEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateCountry", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteCountry", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CountryEntity>> GetBy(string name)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<CountryEntity>("GetCountriesBy", new { name }, commandType: CommandType.StoredProcedure);
        }
    }
}
