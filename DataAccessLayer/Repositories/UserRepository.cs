using Dapper;
using DataAccessLayer.Interfaces;
using ORM.Attributes;
using ORM.Models;
using System.Data;
using System.Threading.Tasks;

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
            return db.QueryFirstOrDefault<User>($"SELECT * FROM {tableName} WHERE FirstName = '{name}'");
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var tableName = typeof(User).GetTableAttributeValue((AirportTableAttribute att) => att.Name);
            using IDbConnection db = new ApplicationContext().OpenConnection();
            return await db.QueryFirstOrDefaultAsync<User>($"SELECT * FROM {tableName} WHERE FirstName = '{name}'");
        }
    }
}
