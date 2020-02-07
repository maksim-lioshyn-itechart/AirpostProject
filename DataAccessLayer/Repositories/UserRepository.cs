using Dapper;
using DataAccessLayer.Interfaces;
using ORM;
using ORM.Attributes;
using ORM.Models;
using System.Data;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User GetByName(string name)
        {
            var tableName = typeof(User).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
            using IDbConnection db = new ApplicationContext().OpenConnection(); 
            return db.Query<User>($"SELECT * FROM {tableName} WHERE FirstName = '{name}'", new { name }).FirstOrDefault();
        }
    }
}
