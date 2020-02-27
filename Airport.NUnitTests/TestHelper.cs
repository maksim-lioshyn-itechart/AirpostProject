using AirportProject.NUnitTests;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Tests
{
    public static class TestHelper
    {
        public static Test Test = new Test();
        public static IAirplaneSchemaRepository AirplaneSchema = new AirplaneSchemaRepository(Test);
        public static IAirlineRepository Airline = new AirlineRepository(Test);
        public static IAirplaneRepository Airplane = new AirplaneRepository(Test);
        public static IAirplaneSubTypeRepository AirplaneSubType = new AirplaneSubTypeRepository(Test);
        public static IAirplaneTypeRepository AirplaneType = new AirplaneTypeRepository(Test);
        public static IAirportRepository Airport = new AirportRepository(Test);
        public static IClassTypeRepository ClassType = new ClassTypeRepository(Test);
        public static ICountryRepository Country = new CountryRepository(Test);
        public static IDocumentRepository Document = new DocumentRepository(Test);
        public static IDocumentTypeRepository DocumentType = new DocumentTypeRepository(Test);
        public static IFlightRepository Flight = new FlightRepository(Test);
        public static IOrderStatusRepository OrderStatus = new OrderStatusRepository(Test);
        public static IPassengerSeatRepository PassengerSeat = new PassengerSeatRepository(Test);
        public static ITicketRepository Ticket = new TicketRepository(Test);
        public static IUserPasswordRepository UserPassword = new UserPasswordRepository(Test);
        public static IUserRepository User = new UserRepository(Test);
        public static IUserRoleRepository UserRole = new UserRoleRepository(Test);


        public static void CreateEntitiesForAirportService()
        {
            Country.Create(StubsObjects.Country.ToEntity());
        }

        public static void DeleteEntitiesForAirportService()
        {
            Country.Delete(StubsObjects.Country.Id);
        }

        public static void CreateEntitiesForAirplaneService()
        {
            CreateEntitiesForAirportService();
            AirplaneSchema.Create(StubsObjects.AirplaneSchema.ToEntity());
            AirplaneType.Create(StubsObjects.AirplaneType.ToEntity());
            AirplaneSubType.Create(StubsObjects.AirplaneSubType.ToEntity());
            Airline.Create(StubsObjects.Airline.ToEntity());
        }

        public static void DeleteEntitiesForAirplaneService()
        {
            DeleteEntitiesForAirportService();
            AirplaneSchema.Delete(StubsObjects.AirplaneSchema.Id);
            AirplaneType.Delete(StubsObjects.AirplaneType.Id);
            AirplaneSubType.Delete(StubsObjects.AirplaneSubType.Id);
            Airline.Delete(StubsObjects.Airline.Id);
        }

        public static void CreateEntitiesForDocumentService()
        {
            DocumentType.Create(StubsObjects.DocumentType.ToEntity());
        }

        public static void DeleteEntitiesForDocumentService()
        {
            DocumentType.Delete(StubsObjects.DocumentType.Id);
        }

        public static void CreateEntitiesForUserService()
        {
            UserRole.Create(StubsObjects.UserRole.ToEntity());
        }

        public static void DeleteEntitiesForUserService()
        {
            UserRole.Delete(StubsObjects.UserRole.Id);
        }
        public static void CreateEntitiesForPassengerSeatService()
        {
            AirplaneSchema.Create(StubsObjects.AirplaneSchema.ToEntity());
            ClassType.Create(StubsObjects.ClassType.ToEntity());
        }

        public static void DeleteEntitiesForPassengerSeatService()
        {
            AirplaneSchema.Delete(StubsObjects.AirplaneSchema.Id);
            ClassType.Delete(StubsObjects.ClassType.Id);
        }

        public static void CreateEntitiesForFlightService()
        {
            CreateEntitiesForAirplaneService();
            CreateEntitiesForAirportService();
            Airplane.Create(StubsObjects.Airplane.ToEntity());
            Airport.Create(StubsObjects.Airport.ToEntity());

        }

        public static void DeleteEntitiesForFlightService()
        {
            DeleteEntitiesForAirplaneService();
            DeleteEntitiesForAirportService();
            Airplane.Delete(StubsObjects.Airplane.Id);
            Airport.Delete(StubsObjects.Airport.Id);
        }

        public static void CreateEntitiesForTicketService()
        {
            CreateEntitiesForFlightService();
            CreateEntitiesForDocumentService();

            Flight.Create(StubsObjects.Flight.ToEntity()).Wait();

            ClassType.Create(StubsObjects.ClassType.ToEntity());
            PassengerSeat.Create(StubsObjects.PassengerSeat.ToEntity());
            OrderStatus.Create(StubsObjects.OrderStatus.ToEntity());
            Document.Create(StubsObjects.Document.ToEntity());
        }

        public static void DeleteEntitiesForTicketService()
        {
            DeleteEntitiesForFlightService();
            DeleteEntitiesForDocumentService();
            Flight.Delete(StubsObjects.Flight.Id);
            ClassType.Delete(StubsObjects.ClassType.Id);
            PassengerSeat.Delete(StubsObjects.PassengerSeat.Id);
            OrderStatus.Delete(StubsObjects.OrderStatus.Id);
            Document.Delete(StubsObjects.Document.Id);
        }
    }
}
