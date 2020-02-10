﻿using System;
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
            _countryRepository = new CountryRepository(new UnitOfWork(new ApplicationContext()));
        }

        [Test]
        [Order(0)]
        public void CountryRepository_CreateTest_CreateTestCountry()
        {
            _countryRepository.Create(Country);
        }

        [Test]
        [Order(1)]
        public void CountryRepository_GetByIdTest_ReturnTestCountry()
        {
            var country = _countryRepository.GetById(Country.Id);
            Assert.AreEqual(country.Id, Country.Id);
        }

        [Test]
        [Order(3)]
        public void CountryRepository_GetAllTest_ReturnAllRoles()
        {
            var countries = _countryRepository.GetAll();
            Assert.Greater(countries.Count, 0);
        }

        [Test]
        [Order(99)]
        public void CountryRepository_UpdateTest_UpdateTestCountry()
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
        public void CountryRepository_DeleteTest_DeleteTestCountry()
        {
            _countryRepository.Delete(Country.Id);
        }
    }
}