using System;
using BusinessLogicLayer.Models;

namespace AirportProject.NUnitTests
{
    public static class StubsObjects
    {
        public static Country Country = new Country()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            Code = Guid.NewGuid().ToString().Substring(0, 4)
        };

        public static AirplaneSchema AirplaneSchema = new AirplaneSchema()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static AirplaneSubType AirplaneSubType = new AirplaneSubType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static AirplaneType AirplaneType = new AirplaneType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static ClassType ClassType = new ClassType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static DocumentType DocumentType = new DocumentType()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };

        public static OrderStatus OrderStatus = new OrderStatus()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString().Substring(0, 8)
        };

        public static UserRole UserRole = new UserRole()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        };



        public static Airline Airline = new Airline()
        {
            Id = Guid.NewGuid(),
            Email = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Address = Guid.NewGuid().ToString(),
            Phone = Guid.NewGuid().ToString().Substring(0, 8),
            Url = Guid.NewGuid().ToString(),
            CountryId = Country.Id
        };

        public static Airport Airport = new Airport()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            CountryId = Country.Id,
            IsActive = true
        };

        public static Document Document = new Document()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            Number = Guid.NewGuid().ToString(),
            DocumentTypeId = DocumentType.Id,
            IsActive = true
        };

        public static User User = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = Guid.NewGuid().ToString(),
            Address = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            Phone = Guid.NewGuid().ToString().Substring(0, 8),
            Password = Guid.NewGuid().ToString(),
            RoleId = UserRole.Id
        };

        public static PassengerSeat PassengerSeat = new PassengerSeat
        {
            Id = Guid.NewGuid(),
            Seat = 0,
            Row = 0,
            Floor = 0,
            Sector = "aa",
            ClassTypeId = ClassType.Id,
            AirplaneSchemaId = AirplaneSchema.Id,
            CoordinateX1 = 0,
            CoordinateX2 = 0,
            CoordinateY1 = 0,
            CoordinateY2 = 0
        };


        public static Airplane Airplane = new Airplane
        {
            Id = Guid.NewGuid(),
            AirlineId = Airline.Id,
            AirplaneSchemaId = AirplaneSchema.Id,
            AirplaneSubTypeId = AirplaneSubType.Id,
            AirplaneTypeId = AirplaneType.Id,
            CarryingCapacity = 100,
            Name = Guid.NewGuid().ToString().Substring(0, 4)
        };

        
        public static Flight Flight = new Flight
        {
            Id = Guid.NewGuid(),
            ArrivalTimeUtc = DateTime.UtcNow,
            DepartureTimeUtc = DateTime.UtcNow,
            AirplaneId = Airplane.Id,
            DepartureAirportId = Airport.Id,
            DestinationAirportId = Airport.Id
        };

        public static Ticket Ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            BaggageCount = 0,
            TicketNumber = Guid.NewGuid().ToString().Substring(0, 4),
            Cost = 100,
            DocumentId = Document.Id,
            FlightId = Flight.Id,
            FreeWeightCapacity = 100,
            OrderStatusId = OrderStatus.Id,
            OverWeightPrice = 200,
            PassengerSeatId = PassengerSeat.Id,
            PurchaseDate = DateTime.UtcNow,
            Taxes = 2131,
            Total = 54654
        };
    }
}
