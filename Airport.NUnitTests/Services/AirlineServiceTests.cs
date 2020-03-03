using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Tests;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class AirlineServiceTests
    {
        private readonly IAirlineService _testEntityService;
        private readonly Airline _entityBm = StubsObjects.Airline;

        public AirlineServiceTests()
        {
            _testEntityService = new AirlineService(TestHelper.Airline);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForAirportService();
            Assert.IsTrue(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.AlreadyExists);
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
            var airline = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.Address, airline.Address);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.Email = "Test";
            _testEntityService.Update(test).Wait();
            var airline = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(airline.Email, test.Email);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            TestHelper.DeleteEntitiesForAirportService();
            _testEntityService.Delete(_entityBm).Wait();
        }
    }
}