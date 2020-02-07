using Dapper;
using DataAccessLayer.Interfaces;
using ORM;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public ApplicationContext Context { get; }

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }

        public void Saving(string sqlQuery)
        {
            using IDbConnection db = Context.OpenConnection();
            db.Execute(sqlQuery);
        }
    }
}
