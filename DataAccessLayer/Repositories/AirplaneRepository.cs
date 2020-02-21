using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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
            await db.ExecuteAsync("InsertAirplane", entity, commandType: CommandType.StoredProcedure);
        }
        
        public async Task<Airplane> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Airplane>("GetByIdAirplane", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Airplane>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Airplane>("GetAllAirplane", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Airplane entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateAirplane", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteAirplane", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
