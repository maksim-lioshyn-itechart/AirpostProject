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
    public class CountryServiceTests
    {
        private readonly ICountryService _testEntityService;

        private readonly Country _entityBm = StubsObjects.Country;

        public CountryServiceTests()
        {
            _testEntityService = new CountryService(TestHelper.Country);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
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
            Assert.AreEqual(_entityBm.Name, airline.Name);
        }

        [Test()]
        [Order(2)]
        public void UpdateTest()
        {
            var test = _entityBm;
            test.Name = Guid.NewGuid().ToString();
            _testEntityService.Update(test).Wait();
            var airline = _testEntityService.GetById(_entityBm.Id).Result;
            Assert.AreEqual(airline.Name, test.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _testEntityService.Delete(_entityBm).Wait();
        }
    }
}