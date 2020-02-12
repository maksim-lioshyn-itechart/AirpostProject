using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class SchemaRepository : ISchemaRepository
    {
        public void Create(Schema entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.ExecuteScalar("INSERT INTO Schemas (Id, Code, AirPlaneId, PlaceId, IsActive, Price, PlaceNumber) " +
                             "VALUES (@Id, @Code, @AirPlaneId, @PlaceId, @IsActive, @Price, @PlaceNumber)", entity);
        }

        public Schema GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Schema>("SELECT * FROM Schemas WHERE Id = @Id", new { id });
        }

        public IEnumerable<Schema> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<Schema>("SELECT * FROM Schemas");
        }

        public void Update(Schema entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
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
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM Schemas WHERE Id = @Id", new { id });
        }
    }
}
