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
        public async Task Create(Ticket entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            await db.ExecuteAsync("InsertTicket", entity, commandType: CommandType.StoredProcedure);
        }

        public async Task<Ticket> GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QuerySingleAsync<Ticket>("GetTicketById", new { id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return await db.QueryAsync<Ticket>("GetAllTickets", commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Ticket entity)
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
