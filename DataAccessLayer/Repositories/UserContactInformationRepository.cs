using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class UserContactInformationRepository : IUserContactInformationRepository
    {
        public void Create(UserContactInformation entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("INSERT INTO " +
                             "UserContactInformation (Id, UserId, Phone, Address, Email) " +
                             "VALUES (@Id, @UserId, @Phone, @Address, @Email)", entity);
        }

        public UserContactInformation GetById(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.QuerySingle<UserContactInformation>("SELECT * FROM UserContactInformation WHERE Id = @Id", new { id });
        }

        public IEnumerable<UserContactInformation> GetAll()
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<UserContactInformation>("SELECT * FROM UserContactInformation");
        }

        public void Update(UserContactInformation entity)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("UPDATE UserContactInformation SET " +
                                  "UserId = @UserId, " +
                                  "Phone = @Phone, " +
                                  "Address = @Address, " +
                                  "Email = @Email " +
                                  "WHERE Id = @Id", entity);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            db.Execute("DELETE FROM UserContactInformation WHERE Id = @Id", new { id });
        }

        public IEnumerable<UserContactInformation> GetUserContactInformation(User user)
        {
            using IDbConnection db = new ConnectionFactory().GetOpenConnection();
            return db.Query<UserContactInformation>($"SELECT * FROM UserContactInformation WHERE UserId = @Id", new { user.Id });
        }
    }
}
