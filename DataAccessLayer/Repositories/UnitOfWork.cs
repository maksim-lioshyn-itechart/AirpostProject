using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public IConfigurationFactory ConfigurationFactory { get; }
        
        private readonly UserRoleRepository _userRoleRepository;
        private readonly AirlineRepository _airlineRepository;

        public IAirlineRepository AirlineRepository =>
            _airlineRepository ?? new AirlineRepository(ConfigurationFactory);
        public IUserRoleRepository UserRoleRepository =>
            _userRoleRepository ?? new UserRoleRepository(ConfigurationFactory);

        public UnitOfWork(
            IConfigurationFactory configurationFactory,
            UserRoleRepository userRoleRepository, 
            AirlineRepository airlineRepository)
        {
            ConfigurationFactory = configurationFactory;
            _userRoleRepository = userRoleRepository;
            _airlineRepository = airlineRepository;
        }

        
    }
}
