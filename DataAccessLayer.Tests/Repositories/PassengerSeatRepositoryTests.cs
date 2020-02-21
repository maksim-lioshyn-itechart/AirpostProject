using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class PassengerSeatRepositoryTests
    {
        private readonly IBaseRepository<PassengerSeat> _repository;

        static readonly AirplaneSchema _entityAirplaneSchema = new AirplaneSchema()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
        };

        readonly PassengerSeat _entity = new PassengerSeat()
        {
            Id = Guid.NewGuid(),
            CoordinateX1 = 1,
            Sector = "2",
            ClassTypeId = Guid.Parse("F9870902-51AD-4C7A-9277-424E5564D8E4"),
            AirplaneSchemaId = _entityAirplaneSchema.Id,
            CoordinateX2 = 1,
            CoordinateY1 = 1,
            CoordinateY2 = 1,
            Floor = 1,
            Row = 1,
            Seat = 10
        };

        public PassengerSeatRepositoryTests()
        {
            _repository = new PassengerSeatRepository(new Test());
        }

        [Test()]
        [Order(1)]
        public void CreateTest()
        {
            new AirplaneSchemaRepository(new Test()).Create(_entityAirplaneSchema).Wait();
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
            var tests = _repository.GetAll().Result;
            Assert.GreaterOrEqual(tests.AsList().Count, 1);
        }

        [Test()]
        [Order(4)]
        public void UpdateTest()
        {
            var test = _entity;
            test.CoordinateX1 = 100;
            _repository.Update(test).Wait();
            var testnew = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(testnew.CoordinateX1, _entity.CoordinateX1);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
            new AirplaneSchemaRepository(new Test()).Delete(_entityAirplaneSchema.Id).Wait();
        }
    }
}