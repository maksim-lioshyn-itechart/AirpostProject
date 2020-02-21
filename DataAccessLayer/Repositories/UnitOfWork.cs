using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public IConfigurationFactory ConfigurationFactory { get; }
        private readonly UserRoleRepository _userRoleRepository;

        public IUserRoleRepository UserRoleRepository =>
            _userRoleRepository ?? new UserRoleRepository(ConfigurationFactory);

        public UnitOfWork(
            IConfigurationFactory configurationFactory,
            UserRoleRepository userRoleRepository
            )
        {
            ConfigurationFactory = configurationFactory;
            _userRoleRepository = userRoleRepository;
        }
    }
}
