using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IConfigurationFactory ConfigurationFactory { get; }

        private readonly AirplaneSchemaRepository _airplaneSchema;
        private readonly AirlineRepository _airline;
        private readonly AirplaneSubTypeRepository _airplaneSubType;
        private readonly AirportRepository _airport;
        private readonly ClassTypeRepository _classType;
        private readonly CountryRepository _country;
        private readonly DocumentRepository _document;
        private readonly DocumentTypeRepository _documentType;
        private readonly FlightRepository _flight;
        private readonly OrderStatusRepository _orderStatus;
        private readonly PassengerSeatRepository _passengerSeat;
        private readonly TicketRepository _ticket;
        private readonly UserPasswordRepository _userPassword;
        private readonly UserRepository _user;
        private readonly UserRoleRepository _userRole;
        private readonly AirplaneTypeRepository _airplaneType;
        private readonly AirplaneRepository _airplane;

        public IAirlineRepository Airline =>
            _airline ?? new AirlineRepository(ConfigurationFactory);

        public IAirplaneRepository Airplane =>
            _airplane ?? new AirplaneRepository(ConfigurationFactory);

        public IAirplaneSchemaRepository AirplaneSchema =>
            _airplaneSchema ?? new AirplaneSchemaRepository(ConfigurationFactory);

        public IAirplaneSubTypeRepository AirplaneSubType =>
            _airplaneSubType ?? new AirplaneSubTypeRepository(ConfigurationFactory);

        public IAirplaneTypeRepository AirplaneType =>
            _airplaneType ?? new AirplaneTypeRepository(ConfigurationFactory);

        public IAirportRepository Airport =>
            _airport ?? new AirportRepository(ConfigurationFactory);

        public IClassTypeRepository ClassType =>
            _classType ?? new ClassTypeRepository(ConfigurationFactory);

        public ICountryRepository Country =>
            _country ?? new CountryRepository(ConfigurationFactory);

        public IDocumentRepository Document =>
            _document ?? new DocumentRepository(ConfigurationFactory);

        public IDocumentTypeRepository DocumentType =>
            _documentType ?? new DocumentTypeRepository(ConfigurationFactory);

        public IFlightRepository Flight =>
            _flight ?? new FlightRepository(ConfigurationFactory);

        public IOrderStatusRepository OrderStatus =>
            _orderStatus ?? new OrderStatusRepository(ConfigurationFactory);

        public IPassengerSeatRepository PassengerSeat =>
            _passengerSeat ?? new PassengerSeatRepository(ConfigurationFactory);

        public ITicketRepository Ticket =>
            _ticket ?? new TicketRepository(ConfigurationFactory);

        public IUserPasswordRepository UserPassword =>
            _userPassword ?? new UserPasswordRepository(ConfigurationFactory);

        public IUserRepository User =>
            _user ?? new UserRepository(ConfigurationFactory);

        public IUserRoleRepository UserRole =>
            _userRole ?? new UserRoleRepository(ConfigurationFactory);

        public UnitOfWork(
            IConfigurationFactory configurationFactory,
            AirplaneSchemaRepository airplaneSchema,
            AirlineRepository airline,
            AirplaneRepository airplane,
            AirplaneSubTypeRepository airplaneSubType,
            AirplaneTypeRepository airplaneType,
            AirportRepository airport,
            ClassTypeRepository classType,
            CountryRepository country,
            DocumentRepository document,
            DocumentTypeRepository documentType,
            FlightRepository flight,
            OrderStatusRepository orderStatus,
            PassengerSeatRepository passengerSeat,
            TicketRepository ticket,
            UserPasswordRepository userPassword,
            UserRepository user,
            UserRoleRepository userRole)
        {
            ConfigurationFactory = configurationFactory;
            _airplaneSchema = airplaneSchema;
            _airline = airline;
            _airplaneSubType = airplaneSubType;
            _airport = airport;
            _classType = classType;
            _country = country;
            _document = document;
            _documentType = documentType;
            _flight = flight;
            _orderStatus = orderStatus;
            _passengerSeat = passengerSeat;
            _ticket = ticket;
            _userPassword = userPassword;
            _user = user;
            _userRole = userRole;
            _airplane = airplane;
            _airplaneType = airplaneType;
        }
    }
}
