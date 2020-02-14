using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class AirplaneSchemaRepository : IAirplaneSchemaRepository
    {
        private readonly IConfigurationFactory _configuration;

        public AirplaneSchemaRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }

        public void Create(AirplaneSchema entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.ExecuteScalar("INSERT INTO Schemas (Id, Code, AirPlaneId, PlaceId, IsActive, Price, PlaceNumber) " +
                             "VALUES (@Id, @Code, @AirPlaneId, @PlaceId, @IsActive, @Price, @PlaceNumber)", entity);
        }

        public AirplaneSchema GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QuerySingle<AirplaneSchema>("SELECT * FROM Schemas WHERE Id = @Id", new { id });
        }

        public IEnumerable<AirplaneSchema> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.Query<AirplaneSchema>("SELECT * FROM Schemas");
        }

        public void Update(AirplaneSchema entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("UPDATE Schemas SET " +
                       "Code = @Code, " +
                       "AirPlaneId = @AirPlaneId, " +
                       "PlaceId = @PlaceId, " +
                       "IsActive = @IsActive " +
                       "Price = @Price " +
                       "PlaceNumber = @PlaceNumber " +
                       "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("DELETE FROM Schemas WHERE Id = @Id", new { id });
        }
    }
}
