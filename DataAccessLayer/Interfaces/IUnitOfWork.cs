namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IAirlineRepository Airline { get; }
        IAirplaneRepository Airplane { get; }
        IAirplaneSchemaRepository AirplaneSchema { get; }
        IAirplaneSubTypeRepository AirplaneSubType { get; }
        IAirplaneTypeRepository AirplaneType { get; }
        IAirportRepository Airport { get; }

        IClassTypeRepository ClassType { get; }

        ICountryRepository Country { get; }
        IDocumentRepository Document { get; }
        IDocumentTypeRepository DocumentType { get; }
        IFlightRepository Flight { get; }
        IOrderStatusRepository OrderStatus { get; }
        IPassengerSeatRepository PassengerSeat { get; }

        ITicketRepository Ticket { get; }

        IUserPasswordRepository UserPassword { get; }

        IUserRepository User { get; }

        IUserRoleRepository UserRole { get; }


    }
}
