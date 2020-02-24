using System;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Services
{
    [TestFixture()]
    public class AirlineServiceTests
    {
        private readonly IAirlineService _testEntityService;

        private readonly AirlineBm _entityBm = new AirlineBm()
        {
            Id = Guid.NewGuid(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Address = Guid.NewGuid().ToString(),
            Phone = "12093",
            Url = Guid.NewGuid().ToString(),
            CountryId = Guid.Parse("28E0F235-64E2-4A82-A0D0-3D62E6E0F4D5")
        };

        public AirlineServiceTests()
        {
            _testEntityService = new AirlineService(TestHelper.UnitOfWork);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
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
            _testEntityService.Delete(_entityBm).Wait();
        }
    }
}