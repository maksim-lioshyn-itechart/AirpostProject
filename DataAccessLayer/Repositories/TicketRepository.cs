using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IConfigurationFactory _configuration;

        public TicketRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(TicketEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertTicket", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<TicketEntity> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleOrDefaultAsync<TicketEntity>("GetTicketById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TicketEntity>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<TicketEntity>("GetAllTickets", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(TicketEntity entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("UpdateTicket", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("DeleteTicket", new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
