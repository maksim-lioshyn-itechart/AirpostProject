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
            UnitOfWork.AirplaneSchema.Create(StubsObjects.AirplaneSchemaBm.ToDal());
            UnitOfWork.AirplaneType.Create(StubsObjects.AirplaneTypeBm.ToDal());
            UnitOfWork.AirplaneSubType.Create(StubsObjects.AirplaneSubTypeBm.ToDal());
            UnitOfWork.Airline.Create(StubsObjects.AirlineBm.ToDal());
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
            UnitOfWork.Country.Create(StubsObjects.CountryBm.ToDal());
        }

        public static void DeleteEntitiesForAirportService()
        {
            UnitOfWork.Country.Delete(StubsObjects.CountryBm.Id);
        }

        public static void CreateEntitiesForDocumentService()
        {
            UnitOfWork.DocumentType.Create(StubsObjects.DocumentTypeBm.ToDal());
        }

        public static void DeleteEntitiesForDocumentService()
        {
            UnitOfWork.DocumentType.Delete(StubsObjects.DocumentTypeBm.Id);
        }

        public static void CreateEntitiesForUserService()
        {
            UnitOfWork.UserRole.Create(StubsObjects.UserRoleBm.ToDal());
        }

        public static void DeleteEntitiesForUserService()
        {
            UnitOfWork.UserRole.Delete(StubsObjects.UserRoleBm.Id);
        }
        public static void CreateEntitiesForPassengerSeatService()
        {
            UnitOfWork.AirplaneSchema.Create(StubsObjects.AirplaneSchemaBm.ToDal());
            UnitOfWork.ClassType.Create(StubsObjects.ClassTypeBm.ToDal());
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
            UnitOfWork.Airplane.Create(StubsObjects.AirplaneBm.ToDal());
            UnitOfWork.Airport.Create(StubsObjects.AirportBm.ToDal());

        }

        public static void DeleteEntitiesForFlightService()
        {
            DeleteEntitiesForAirplaneService();
            DeleteEntitiesForAirportService();
            UnitOfWork.Airplane.Delete(StubsObjects.AirplaneBm.Id);
            UnitOfWork.Airport.Delete(StubsObjects.AirportBm.Id);
        }
    }
}
