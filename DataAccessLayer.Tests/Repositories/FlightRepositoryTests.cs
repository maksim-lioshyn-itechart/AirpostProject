using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class FlightRepositoryTests
    {
        private readonly IBaseRepository<Flight> _repository;


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

        static readonly Airplane _entityAirplane = new Airplane()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            AirplaneSchemaId = _entitySchema.Id,
            AirplaneSubTypeId = _entitySubType.Id,
            AirplaneTypeId = _entityType.Id,
            CarryingCapacity = 100,
            AirlineId = _entityAirline.Id
        };

        static readonly Airport _entityAirport = new Airport()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            IsActive = true,
            CountryId = Guid.Parse("28E0F235-64E2-4A82-A0D0-3D62E6E0F4D5")
        };

        readonly Flight _entity = new Flight()
        {
            Id = Guid.NewGuid(),
            AirplaneId = _entityAirplane.Id,
            ArrivalTimeUtc = DateTime.Now,
            DepartureTimeUtc = DateTime.Now,
            DepartureAirportId = _entityAirport.Id,
            DestinationAirportId = _entityAirport.Id
        };

        public FlightRepositoryTests()
        {
            new AirplaneSchemaRepository(new Test()).Create(_entitySchema).Wait();
            new AirplaneTypeRepository(new Test()).Create(_entityType).Wait();
            new AirplaneSubTypeRepository(new Test()).Create(_entitySubType).Wait();
            new AirlineRepository(new Test()).Create(_entityAirline).Wait();
            new AirplaneRepository(new Test()).Create(_entityAirplane).Wait();
            new AirportRepository(new Test()).Create(_entityAirport).Wait();
            _repository = new FlightRepository(new Test());
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
            var dt = DateTime.UtcNow;
            test.DepartureTimeUtc = dt;
            _repository.Update(test).Wait();
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.DepartureTimeUtc.Hour, dt.Hour);
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();
            new AirportRepository(new Test()).Delete(_entityAirport.Id).Wait();
            new AirplaneRepository(new Test()).Delete(_entityAirplane.Id).Wait();
            new AirlineRepository(new Test()).Delete(_entityAirline.Id).Wait();

            new AirplaneTypeRepository(new Test()).Delete(_entityType.Id).Wait();
            new AirplaneSubTypeRepository(new Test()).Delete(_entitySubType.Id).Wait();
            new AirplaneSchemaRepository(new Test()).Delete(_entitySchema.Id).Wait();


            

        }
    }
}