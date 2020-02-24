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
    }
}
