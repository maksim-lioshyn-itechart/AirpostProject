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
    public class AirlineRepositoryTests
    {
        private readonly IBaseRepository<Airline> _repository;

        readonly Airline _entity = new Airline()
        {
            Id = Guid.NewGuid(),
            Address = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Phone = Guid.NewGuid().ToString(),
            Url = Guid.NewGuid().ToString()
        };

        public AirlineRepositoryTests()
        {
            _repository = new AirlineRepository(new Test());
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
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.Id, _entity.Id);
        }

        [Test()]
        [Order(3)]
        public void GetAllTest()
        {
            var airlines = _repository.GetAll().Result;
            Assert.Greater(airlines.AsList().Count, 2);
        }

        [Test()]
        [Order(4)]
        public void UpdateTest()
        {
            var test = _entity;
            test.Name = "Test";
            _repository.Update(test).Wait();
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.Name, _entity.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
        }
    }
}