using System;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class AirportRepositoryTests
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IAirportRepository _airportRepository;
        private static readonly Country Country = new Country
        {
            Id = Guid.NewGuid(),
            Name = "TestCountry",
            Code = "TestCode"
        };

        private readonly Airport _airport = new Airport
        {
            Id = Guid.NewGuid(),
            CountryId = Country.Id,
            IsActive = true,
            Name = Guid.NewGuid().ToString()
        };

        public AirportRepositoryTests()
        {
            _countryRepository = new CountryRepository(new UnitOfWork(new ORM.ApplicationContext()));
            _airportRepository = new AirportRepository(new UnitOfWork(new ORM.ApplicationContext()));
        }

        [Test]
        [Order(0)]
        public void CreateTest()
        {
            _countryRepository.Create(Country);
            _airportRepository.Create(_airport);
        }

        [Test]
        [Order(1)]
        public void GetByIdTest()
        {
            var airport = _airportRepository.GetById(_airport.Id);
            Assert.AreEqual(airport.Id, _airport.Id);
        }

        [Test]
        [Order(3)]
        public void GetAllTest()
        {
            var airports = _airportRepository.GetAll();
            Assert.IsTrue(airports.Count > 0);
        }

        [Test]
        [Order(4)]
        public void AssignRoleToUserByIdTest()
        {
            _airportRepository.AssignAirportToCountry(_airport.Id, Country.Id);
            var airport = _airportRepository.GetById(_airport.Id);
            Assert.AreEqual(airport.CountryId, Country.Id);
        }


        [Test]
        [Order(99)]
        public void UpdateTest()
        {
            var newName = "newName";
            var airport = _airportRepository.GetById(_airport.Id);
            airport.Name = newName;
            _airportRepository.Update(airport);
            var test = _airportRepository.GetById(_airport.Id);
            Assert.AreEqual(newName, test.Name);
        }

        [Test]
        [Order(100)]
        public void DeleteTest()
        {
            _countryRepository.Delete(Country.Id);
            _airportRepository.Delete(_airport.Id);
        }
    }
}