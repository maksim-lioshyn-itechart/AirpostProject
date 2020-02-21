using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class AirplaneRepositoryTests
    {
        private readonly IBaseRepository<Airplane> _repository;


        static readonly AirplaneSubType _entitySubType = new AirplaneSubType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
        };

        static readonly AirplaneType _entityType = new AirplaneType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
        };

        static readonly AirplaneSchema _entitySchema = new AirplaneSchema()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
        };

        static readonly Airline _entityAirline = new Airline()
        {
            Id = Guid.NewGuid(),
            Address = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Phone = Guid.NewGuid().ToString(),
            Url = Guid.NewGuid().ToString()
        };

        readonly Airplane _entity = new Airplane()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            AirplaneSchemaId = _entitySchema.Id,
            AirplaneSubTypeId = _entitySubType.Id,
            AirplaneTypeId = _entityType.Id,
            CarryingCapacity = 100,
            AirlineId = _entityAirline.Id
        };

        public AirplaneRepositoryTests()
        {
            new AirplaneSchemaRepository(new Test()).Create(_entitySchema).Wait();
            new AirplaneTypeRepository(new Test()).Create(_entityType).Wait();
            new AirplaneSubTypeRepository(new Test()).Create(_entitySubType).Wait();
            new AirlineRepository(new Test()).Create(_entityAirline).Wait();
            _repository = new AirplaneRepository(new Test());
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
            var tests = _repository.GetAll().Result;
            Assert.GreaterOrEqual(tests.AsList().Count, 1);
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
            new AirplaneSchemaRepository(new Test()).Delete(_entitySchema.Id).Wait();
            new AirplaneTypeRepository(new Test()).Delete(_entityType.Id).Wait();
            new AirplaneSubTypeRepository(new Test()).Delete(_entitySubType.Id).Wait();
            new AirlineRepository(new Test()).Delete(_entityAirline.Id).Wait();
            
        }
    }
}