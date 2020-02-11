using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        public void Create(Country entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.ExecuteScalar("INSERT INTO Countries (Id, Name, Code) VALUES (@Id, @Name, @Code)", entity);
        }

        public Country GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<Country>("SELECT * FROM Countries WHERE Id = @Id", new { id });
        }

        public IEnumerable<Country> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<Country>("SELECT * FROM Countries");
        }

        public void Update(Country entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("UPDATE Countries SET Name = @Name, Code = @Code WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM Countries WHERE Id = @Id", new { id });
        }
    }
}
