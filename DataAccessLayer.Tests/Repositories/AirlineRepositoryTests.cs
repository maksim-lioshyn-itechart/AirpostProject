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
        Airline _airline = new Airline()
        {
            Id = Guid.NewGuid(),
            Address = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Phone = Guid.NewGuid().ToString(),
            Url = Guid.NewGuid().ToString()
        };

        [Test()]
        [Order(1)]
        public void CreateTest()
        {
            new AirlineRepository(new Test()).Create(_airline).Wait();
        }

        [Test()]
        [Order(2)]
        public void GetByIdTest()
        {
            var airlineRepository = new AirlineRepository(new Test());
            var airline = airlineRepository.GetById(_airline.Id).Result;
            Assert.AreEqual(airline.Id, _airline.Id);
        }

        [Test()]
        [Order(3)]
        public void GetAllTest()
        {
            var airlineRepository = new AirlineRepository(new Test());
            var airlines = airlineRepository.GetAll().Result;
            Assert.Greater(airlines.AsList().Count, 2);
        }

        [Test()]
        [Order(4)]
        public void UpdateTest()
        {
            var airlineRepository = new AirlineRepository(new Test());
            var test = _airline;
            test.Name = "Test";
            airlineRepository.Update(test).Wait();
            var airline = airlineRepository.GetById(_airline.Id).Result;
            Assert.AreEqual(airline.Name, _airline.Name);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
           new AirlineRepository(new Test()).Delete(_airline.Id).Wait();
        }
    }
}