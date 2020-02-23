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
        private readonly IAirlineService _airlineService;

        private readonly AirlineBM _airlineBm = new AirlineBM()
        {
            Id = Guid.NewGuid(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Address = Guid.NewGuid().ToString(),
            Phone = "12093",
            Url = Guid.NewGuid().ToString(),
            CountryId = Guid.Parse("CBD382E4-4888-48B3-A950-065CFBFED888")
        };

        public AirlineServiceTests()
        {
            IUnitOfWork unitOfWork = new UnitOfWork(
                new Test(), 
                new UserRoleRepository(new Test()), 
                new AirlineRepository(new Test()));
            _airlineService = new AirlineService(unitOfWork);
        }

        [Test()]
        [Order(0)]
        public void CreateTest()
        {
            Assert.IsTrue(_airlineService.Create(_airlineBm).Result);
            Assert.IsFalse(_airlineService.Create(_airlineBm).Result);
        }

        [Test()]
        [Order(1)]
        public void GetAllTest()
        {
            Assert.GreaterOrEqual(_airlineService.GetAll().Result.Count(), 0);
        }

        [Test()]
        [Order(1)]
        public void GetByIdTest()
        {
            var airline = _airlineService.GetById(_airlineBm.Id).Result;
            Assert.AreEqual(_airlineBm.Address, airline.Address);
        }

        [Test()]
        [Order(1)]
        public void UpdateTest()
        {
            var test = _airlineBm;
            test.Email = "Test";
            _airlineService.Update(test).Wait();
            var airline = _airlineService.GetById(_airlineBm.Id).Result;
            Assert.AreEqual(airline.Email, test.Email);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _airlineService.Delete(_airlineBm).Wait();
        }
    }
}