using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class AirportRepository: IAirportRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirportRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public void Create(Airport entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.ExecuteScalar("INSERT INTO Airports (Id, Name, IsActive) VALUES (@Id, @Name, @IsActive)", entity);
        }

        public Airport GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QuerySingle<Airport>("SELECT * FROM Airports WHERE Id = @Id", new { id });
        }

        public IEnumerable<Airport> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.Query<Airport>("SELECT * FROM Airports");
        }

        public void Update(Airport entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("UPDATE Airports SET Name = @Name, IsActive = @IsActive WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("DELETE FROM Airports WHERE Id = @Id", new { id });
        }
    }
}
