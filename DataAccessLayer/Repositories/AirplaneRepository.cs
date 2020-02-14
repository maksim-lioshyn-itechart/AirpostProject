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
        private readonly IConfigurationFactory _configuration;
        public AirplaneRepository(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }
        public void Create(Airplane entity)
        {
            using IDbConnection db = _configuration.GetConnection();
            db.ExecuteScalar("INSERT INTO Airplanes " +
                             "(Id, Name, Type, SubType, CarryingCapacity, OverWeightPrice, FreeWeightCapacity) " +
                             "VALUES (@Id, @Name, @Type, @SubType, @CarryingCapacity, @OverWeightPrice, @FreeWeightCapacity)", entity);
        }

        public Airplane GetById(Guid id)
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.QuerySingle<Airplane>("SELECT * FROM Airplanes WHERE Id = @Id", new { id });
        }

        public IEnumerable<Airplane> GetAll()
        {
            using IDbConnection db = _configuration.GetConnection();
            return db.Query<Airplane>("SELECT * FROM Airplanes");
        }

        public void Update(Airplane entity)
        {
            using IDbConnection db = _configuration.GetConnection();
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
            using IDbConnection db = _configuration.GetConnection();
            db.Execute("DELETE FROM Airplanes WHERE Id = @Id", new { id });
        }
    }
}
