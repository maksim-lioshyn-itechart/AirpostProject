using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.Tests
{
    public static class TestHelper
    {
        public static Test Test = new Test();
        public static IUnitOfWork UnitOfWork = new UnitOfWork(
            Test,
            new UserRoleRepository(Test),
            new AirlineRepository(Test),
            new AirplaneSchemaRepository(Test));
    }
}
