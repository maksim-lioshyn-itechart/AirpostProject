using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class TicketRepository: ITicketRepository
    {
        private readonly IConfigurationFactory _configuration;

        public TicketRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public void Create(Ticket entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.ExecuteScalar("INSERT INTO Tickets (Id, Number, UserId, RaiseId, PlaceType, Cost) " +
                             "VALUES (@Id, @Number, @UserId, @RaiseId, @PlaceType, @Cost)", entity);
        }

        public Ticket GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QuerySingle<Ticket>("SELECT * FROM Tickets WHERE Id = @Id", new { id });
        }

        public IEnumerable<Ticket> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.Query<Ticket>("SELECT * FROM Tickets");
        }

        public void Update(Ticket entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("UPDATE Tickets SET " +
                       "Number = @Number, " +
                       "UserId = @UserId, " +
                       "RaiseId = @RaiseId, " +
                       "PlaceType = @PlaceType, " +
                       "Cost = @Cost" +
                       "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("DELETE FROM Tickets WHERE Id = @Id", new { id });
        }
    }
}
