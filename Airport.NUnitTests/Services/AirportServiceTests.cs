using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Tests;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class AirportServiceTests
    {
        private readonly IAirportService _testEntityService;
        private readonly Airport _entityBm = StubsObjects.Airport;

        public AirportServiceTests()
        {
            _testEntityService = new AirportService(TestHelper.Airport);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForAirportService();

            Assert.IsTrue(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
            Assert.IsFalse(_testEntityService.Create(_entityBm).Result == BusinessLogicLayer.enums.StatusCode.Created);
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
            var airport = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(airport.Name, test.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForAirportService();
        }
    }
}