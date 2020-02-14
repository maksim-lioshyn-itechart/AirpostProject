using Dapper;
using DataAccessLayer.Interfaces;
using System.Data;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IConfigurationFactory _configuration;

        public UnitOfWork(IConfigurationFactory configuration)
        {
            _configuration = configuration;
        }
    }
}
