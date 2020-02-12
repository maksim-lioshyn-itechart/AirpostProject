using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        public void Create(Airplane entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.ExecuteScalar("INSERT INTO Airplanes " +
                             "(Id, Name, Type, SubType, CarryingCapacity, OverWeightPrice, FreeWeightCapacity) " +
                             "VALUES (@Id, @Name, @Type, @SubType, @CarryingCapacity, @OverWeightPrice, @FreeWeightCapacity)", entity);
        }

        public Airplane GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Airplane>("SELECT * FROM Airplanes WHERE Id = @Id", new { id });
        }

        public IEnumerable<Airplane> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<Airplane>("SELECT * FROM Airplanes");
        }

        public void Update(Airplane entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("UPDATE Airplanes SET " +
                       "Name = @Name, " +
                       "SubType = @SubType, " +
                       "CarryingCapacity = @CarryingCapacity, " +
                       "OverWeightPrice = @OverWeightPrice, " +
                       "FreeWeightCapacity = @FreeWeightCapacity" +
                       "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM Airplanes WHERE Id = @Id", new { id });
        }
    }
}
