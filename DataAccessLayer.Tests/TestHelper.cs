using BusinessLogicLayer.Mappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Tests
{
    public static class TestHelper
    {
        public static Test Test = new Test();
        public static IUnitOfWork UnitOfWork = new UnitOfWork(
            Test,
            new AirplaneSchemaRepository(Test),
            new AirlineRepository(Test),
            new AirplaneRepository(Test),
            new AirplaneSubTypeRepository(Test),
            new AirplaneTypeRepository(Test),
            new AirportRepository(Test),
            new ClassTypeRepository(Test),
            new CountryRepository(Test),
            new DocumentRepository(Test),
            new DocumentTypeRepository(Test),
            new FlightRepository(Test),
            new OrderStatusRepository(Test),
            new PassengerSeatRepository(Test),
            new TicketRepository(Test),
            new UserPasswordRepository(Test),
            new UserRepository(Test),
            new UserRoleRepository(Test)
            );


        public static void CreateEntitiesForAirplaneService()
        {
            UnitOfWork.AirplaneSchema.Create(StubsObjects.AirplaneSchemaBm.ToDal()).Wait();
            UnitOfWork.AirplaneType.Create(StubsObjects.AirplaneTypeBm.ToDal()).Wait();
            UnitOfWork.AirplaneSubType.Create(StubsObjects.AirplaneSubTypeBm.ToDal()).Wait();
            UnitOfWork.Airline.Create(StubsObjects.AirlineBm.ToDal()).Wait();
        }

        public static void DeleteEntitiesForAirplaneService()
        {
            UnitOfWork.AirplaneSchema.Delete(StubsObjects.AirplaneSchemaBm.Id);
            UnitOfWork.AirplaneType.Delete(StubsObjects.AirplaneTypeBm.Id);
            UnitOfWork.AirplaneSubType.Delete(StubsObjects.AirplaneSubTypeBm.Id);
            UnitOfWork.Airline.Delete(StubsObjects.AirlineBm.Id);
        }

        public static void CreateEntitiesForAirportService()
        {
            UnitOfWork.Country.Create(StubsObjects.CountryBm.ToDal()).Wait();
        }

        public static void DeleteEntitiesForAirportService()
        {
            UnitOfWork.Country.Delete(StubsObjects.CountryBm.Id);
        }

        public static void CreateEntitiesForDocumentService()
        {
            UnitOfWork.DocumentType.Create(StubsObjects.DocumentTypeBm.ToDal()).Wait();
        }

        public static void DeleteEntitiesForDocumentService()
        {
            UnitOfWork.DocumentType.Delete(StubsObjects.DocumentTypeBm.Id);
        }

        public static void CreateEntitiesForUserService()
        {
            UnitOfWork.UserRole.Create(StubsObjects.UserRoleBm.ToDal()).Wait();
        }

        public static void DeleteEntitiesForUserService()
        {
            UnitOfWork.UserRole.Delete(StubsObjects.UserRoleBm.Id);
        }
        public static void CreateEntitiesForPassengerSeatService()
        {
            UnitOfWork.AirplaneSchema.Create(StubsObjects.AirplaneSchemaBm.ToDal()).Wait();
            UnitOfWork.ClassType.Create(StubsObjects.ClassTypeBm.ToDal()).Wait();
        }

        public static void DeleteEntitiesForPassengerSeatService()
        {
            UnitOfWork.AirplaneSchema.Delete(StubsObjects.AirplaneSchemaBm.Id);
            UnitOfWork.ClassType.Delete(StubsObjects.ClassTypeBm.Id);
        }

        public static void CreateEntitiesForFlightService()
        {
            CreateEntitiesForAirplaneService();
            CreateEntitiesForAirportService();
            UnitOfWork.Airplane.Create(StubsObjects.AirplaneBm.ToDal()).Wait();
            UnitOfWork.Airport.Create(StubsObjects.AirportBm.ToDal()).Wait();

        }

        public static void DeleteEntitiesForFlightService()
        {
            DeleteEntitiesForAirplaneService();
            DeleteEntitiesForAirportService();
            UnitOfWork.Airplane.Delete(StubsObjects.AirplaneBm.Id);
            UnitOfWork.Airport.Delete(StubsObjects.AirportBm.Id);
        }

        public static void CreateEntitiesForTicketService()
        {
            CreateEntitiesForFlightService();
            CreateEntitiesForDocumentService();
            UnitOfWork.Flight.Create(StubsObjects.FlightBm.ToDal()).Wait();

            UnitOfWork.ClassType.Create(StubsObjects.ClassTypeBm.ToDal()).Wait();
            UnitOfWork.PassengerSeat.Create(StubsObjects.PassengerSeatBm.ToDal()).Wait();
            UnitOfWork.OrderStatus.Create(StubsObjects.OrderStatusBm.ToDal()).Wait();
            UnitOfWork.Document.Create(StubsObjects.DocumentBm.ToDal()).Wait();
        }

        public static void DeleteEntitiesForTicketService()
        {
            DeleteEntitiesForFlightService();
            DeleteEntitiesForDocumentService();
            UnitOfWork.Flight.Delete(StubsObjects.FlightBm.Id);
            UnitOfWork.ClassType.Delete(StubsObjects.ClassTypeBm.Id);
            UnitOfWork.PassengerSeat.Delete(StubsObjects.PassengerSeatBm.Id);
            UnitOfWork.OrderStatus.Delete(StubsObjects.OrderStatusBm.Id);
            UnitOfWork.Document.Delete(StubsObjects.DocumentBm.Id);
        }
    }
}
