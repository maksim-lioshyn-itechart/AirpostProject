using System;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using NUnit.Framework;
using ORM.Models;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class CountryRepositoryTests
    {
        private readonly ICountryRepository _countryRepository;
        private static readonly Country Country = new Country
        {
            Id = Guid.NewGuid(),
            Name = "TestCountry",
            Code = "TestCode"
        };

        public CountryRepositoryTests()
        {
            _countryRepository = new CountryRepository(new UnitOfWork(new ORM.ApplicationContext()));
        }

        [Test]
        [Order(0)]
        public void CreateTest()
        {
            _countryRepository.Create(Country);
        }

        [Test]
        [Order(1)]
        public void GetByIdTest()
        {
            var country = _countryRepository.GetById(Country.Id);
            Assert.AreEqual(country.Id, Country.Id);
        }

        [Test]
        [Order(3)]
        public void GetAllTest()
        {
            var countries = _countryRepository.GetAll();
            Assert.IsTrue(countries.Count > 0);
        }

        [Test]
        [Order(99)]
        public void UpdateTest()
        {
            var newName = "newName";
            var country = _countryRepository.GetById(Country.Id);
            country.Name = newName;
            _countryRepository.Update(country);
            var test = _countryRepository.GetById(Country.Id);
            Assert.AreEqual(newName, test.Name);
        }

        [Test]
        [Order(100)]
        public void DeleteTest()
        {
            _countryRepository.Delete(Country.Id);
        }
    }
}