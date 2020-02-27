using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Tests;
using NUnit.Framework;

namespace AirportProject.NUnitTests.Services
{
    [TestFixture()]
    public class PassengerSeatServiceTests
    {
        private readonly IPassengerSeatService _testEntityService;

        private readonly PassengerSeat _entityBm = StubsObjects.PassengerSeat;

        public PassengerSeatServiceTests()
        {
            _testEntityService = new PassengerSeatService(TestHelper.PassengerSeat);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            TestHelper.CreateEntitiesForPassengerSeatService();
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
            var result = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(_entityBm.Sector, result.Sector);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.Sector = "bb";
            _testEntityService.Update(test).Wait();
            var result = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(result.Sector, test.Sector);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
            TestHelper.DeleteEntitiesForPassengerSeatService();

        }
    }
}