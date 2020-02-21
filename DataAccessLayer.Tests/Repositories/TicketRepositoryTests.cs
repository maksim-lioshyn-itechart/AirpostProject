using System;
using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using NUnit.Framework;

namespace DataAccessLayer.Tests.Repositories
{
    [TestFixture()]
    public class TicketRepositoryTests
    {
        private readonly IBaseRepository<Ticket> _repository;

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

        static readonly OrderStatus _entityOrderStatus = new OrderStatus()
        {
            Id = Guid.NewGuid(),
            Name = "TestStatus"

        };

        static readonly DocumentType _entityDocumentType = new DocumentType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),

        };
        
        static readonly AirplaneSchema _entitySchema = new AirplaneSchema()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
        };

        static readonly Document _entityDocument = new Document()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            DocumentTypeId = _entityDocumentType.Id,
            Number = Guid.NewGuid().ToString()
        };
       
        static readonly PassengerSeat _entityPassengerSeat = new PassengerSeat()
        {
            Id = Guid.NewGuid(),
            CoordinateX1 = 1,
            Sector = "2",
            ClassTypeId = Guid.Parse("F9870902-51AD-4C7A-9277-424E5564D8E4"),
            AirplaneSchemaId = _entitySchema.Id,
            CoordinateX2 = 1,
            CoordinateY1 = 1,
            CoordinateY2 = 1,
            Floor = 1,
            Row = 1,
            Seat = 10
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

        static readonly Flight _entityFlight = new Flight()
        {
            Id = Guid.NewGuid(),
            AirplaneId = _entityAirplane.Id,
            ArrivalTimeUtc = DateTime.Now,
            DepartureTimeUtc = DateTime.Now,
            DepartureAirportId = _entityAirport.Id,
            DestinationAirportId = _entityAirport.Id
        };

        readonly Ticket _entity = new Ticket()
        {
            Id = Guid.NewGuid(),
            BaggageCount = 1,
            Cost = 0,
            DocumentId = _entityDocument.Id,
            FlightId = _entityFlight.Id,
            FreeWeightCapacity = 0,
            OrderStatusId = _entityOrderStatus.Id,
            OverWeightPrice = 0,
            PassengerSeatId = _entityPassengerSeat.Id,
            PurchaseDate = DateTime.Now,
            Taxes = 0,
            Total = 0,
            UserId = null,
            TicketNumber = "asdf"
        };

        public TicketRepositoryTests()
        {
            new DocumentTypeRepository(new Test()).Create(_entityDocumentType).Wait();
            new DocumentRepository(new Test()).Create(_entityDocument).Wait();
            new OrderStatusRepository(new Test()).Create(_entityOrderStatus).Wait();
            new AirportRepository(new Test()).Create(_entityAirport).Wait();


            new AirplaneSchemaRepository(new Test()).Create(_entitySchema).Wait();
            new AirplaneTypeRepository(new Test()).Create(_entityType).Wait();
            new AirplaneSubTypeRepository(new Test()).Create(_entitySubType).Wait();
            new AirlineRepository(new Test()).Create(_entityAirline).Wait();
            
            new AirplaneRepository(new Test()).Create(_entityAirplane).Wait();
            new PassengerSeatRepository(new Test()).Create(_entityPassengerSeat).Wait();
            new FlightRepository(new Test()).Create(_entityFlight).Wait();
            _repository = new TicketRepository(new Test());
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
            test.TicketNumber = "Test";
            _repository.Update(test).Wait();
            var airline = _repository.GetById(_entity.Id).Result;
            Assert.AreEqual(airline.TicketNumber, "Test");
        }

        [Test()]
        [Order(100)]
        public void DeleteTest()
        {
            _repository.Delete(_entity.Id).Wait();

            new FlightRepository(new Test()).Delete(_entityFlight.Id).Wait();
            new PassengerSeatRepository(new Test()).Delete(_entityPassengerSeat.Id).Wait();


            new AirportRepository(new Test()).Delete(_entityAirport.Id).Wait();
            new AirplaneRepository(new Test()).Delete(_entityAirplane.Id).Wait();
            new AirlineRepository(new Test()).Delete(_entityAirline.Id).Wait();

            new AirplaneTypeRepository(new Test()).Delete(_entityType.Id).Wait();
            new AirplaneSubTypeRepository(new Test()).Delete(_entitySubType.Id).Wait();
            new AirplaneSchemaRepository(new Test()).Delete(_entitySchema.Id).Wait();

            new OrderStatusRepository(new Test()).Delete(_entityOrderStatus.Id).Wait();
            
            new DocumentRepository(new Test()).Delete(_entityDocument.Id).Wait();
            new DocumentTypeRepository(new Test()).Delete(_entityDocumentType.Id).Wait();
        }
    }
}