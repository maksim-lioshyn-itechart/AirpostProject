using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        public void Create(Place entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.ExecuteScalar("INSERT INTO Places (Id, Code, Type, CoordinateX1, CoordinateX2, CoordinateY1, CoordinateY2) " +
                             "VALUES (@Id, @Code, @Type, @CoordinateX1, @CoordinateX2, @CoordinateY1, @CoordinateY2)", entity);
        }

        public Place GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Place>("SELECT * FROM Places WHERE Id = @Id", new { id });
        }

        public IEnumerable<Place> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<Place>("SELECT * FROM Places");
        }

        public void Update(Place entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("UPDATE Places SET " +
                       "Code = @Code, " +
                       "Type = @Type, " +
                       "CoordinateX1 = @CoordinateX1, " +
                       "CoordinateX2 = @CoordinateX2, " +
                       "CoordinateY1 = @CoordinateY1, " +
                       "CoordinateY2 = @CoordinateY2" +
                       "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM Places WHERE Id = @Id", new { id });
        }
    }
}
