using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class AirportRepositoryTests
    {
        private readonly IBaseRepository<Airport> _repository;

        readonly Airport _entity = new Airport()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            IsActive = true,
            CountryId = Guid.Parse("28E0F235-64E2-4A82-A0D0-3D62E6E0F4D5")
        };

        public AirportRepositoryTests()
        {
            _repository = new AirportRepository(new Test());
        }

        [Test()]
        [Order(1)]
        public void CreateTest()
        {
            _repository.Create(_entity).Wait();
        }

        [Test()]
        [Order(2)]
        public void GetByIdTest()
        {
            var test = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(test.Id, _entity.Id);
        }

        [Test()]
        [Order(3)]
        public void GetAllTest()
        {
            var test = _repository.GetAll().Result;
            Assert.GreaterOrEqual(test.AsList().Count, 0);
        }

        [Test()]
        [Order(4)]
        public void UpdateTest()
        {
            var test = _entity;
            test.Name = "Test";
            _repository.Update(test).Wait();
            var Airport = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(Airport.Name, _entity.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
        }
    }
}