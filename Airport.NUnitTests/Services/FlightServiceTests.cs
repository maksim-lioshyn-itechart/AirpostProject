using System;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Tests;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class FlightServiceTests
    {
        private readonly IFlightService _testEntityService;
        private readonly Flight _entityBm = StubsObjects.Flight;

        public FlightServiceTests()
        {
            _testEntityService = new FlightService(TestHelper.Flight);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForFlightService();

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
            Assert.AreEqual(_entityBm.ArrivalTimeUtc.ToShortDateString(), test.ArrivalTimeUtc.ToShortDateString());
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.DepartureTimeUtc = DateTime.UtcNow;
            _testEntityService.Update(test).Wait();
            var flight = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(flight.DepartureTimeUtc.ToShortDateString(), test.DepartureTimeUtc.ToShortDateString());
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForFlightService();
        }
    }
}