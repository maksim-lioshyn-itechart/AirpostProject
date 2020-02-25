using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using NUnit.Framework;
using System.Linq;

namespace DataAccessLayer.Tests.Services
{
    [TestFixture()]
    public class AirplaneServiceTests
    {
        private readonly IAirplaneService _testEntityService;
        private readonly AirplaneBm _entityBm = StubsObjects.AirplaneBm;

        public AirplaneServiceTests()
        {
            _testEntityService = new AirplaneService(TestHelper.UnitOfWork);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForAirplaneService();

            Assert.IsTrue(_testEntityService.Create(_entityBm).Result);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result);
        }

        [Test()]
        [Order(1)]
        public void GetAllTest()
        {
            Assert.GreaterOrEqual(_testEntityService.GetAll().Result.Count(), 1);
        }

        [Test()]
        [Order(1)]
        public void GetByIdTest()
        {
            var test = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.Name, test.Name);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.Name = "Test";
            _testEntityService.Update(test).Wait();
            var airplane = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(airplane.Name, test.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForAirplaneService();
        }
    }
}