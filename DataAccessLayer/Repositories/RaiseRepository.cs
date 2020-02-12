using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class RaiseRepository : IRaiseRepository
    {
        public void Create(Raise entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.ExecuteScalar("INSERT INTO  Raises (Id, Name, DepartureAirportId, DestinationAirportId, Sortie) " +
                             "VALUES (@Id, @Name, @DepartureAirportId, @DestinationAirportId, @Sortie)", entity);
        }

        public Raise GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Raise>("SELECT * FROM Raises WHERE Id = @Id", new { id });
        }

        public IEnumerable<Raise> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<Raise>("SELECT * FROM Raises");
        }

        public void Update(Raise entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("UPDATE Raises SET " +
                       "Name = @Name " +
                       "DepartureAirportId = @DepartureAirportId " +
                       "DestinationAirportId = @DestinationAirportId " +
                       "Sortie = @Sortie " +
                       "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM Raises WHERE Id = @Id", new { id });
        }
    }
}
