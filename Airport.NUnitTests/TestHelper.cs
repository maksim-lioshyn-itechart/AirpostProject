using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace AirportProject.NUnitTests
{
    public static class TestHelper
    {
        public static Test Test = new Test();
        public static IAirplaneSchemaRepository AirplaneSchema = new AirplaneSchemaRepository(Test);
        public static IAirlineRepository Airline = new AirlineRepository(Test);
        public static IAirplaneRepository Airplane = new AirplaneRepository(Test);
        public static IAirplaneSubTypeRepository AirplaneSubType = new AirplaneSubTypeRepository(Test);
        public static IAirplaneTypeRepository AirplaneType = new AirplaneTypeRepository(Test);
        public static IAirportRepository Airport = new AirportRepository(Test);
        public static IClassTypeRepository ClassType = new ClassTypeRepository(Test);
        public static ICountryRepository Country = new CountryRepository(Test);
        public static IDocumentRepository Document = new DocumentRepository(Test);
        public static IDocumentTypeRepository DocumentType = new DocumentTypeRepository(Test);
        public static IFlightRepository Flight = new FlightRepository(Test);
        public static IOrderStatusRepository OrderStatus = new OrderStatusRepository(Test);
        public static IPassengerSeatRepository PassengerSeat = new PassengerSeatRepository(Test);
        public static ITicketRepository Ticket = new TicketRepository(Test);
        public static IUserPasswordRepository UserPassword = new UserPasswordRepository(Test);
        public static IUserRepository User = new UserRepository(Test);
        public static IUserRoleRepository UserRole = new UserRoleRepository(Test);

        public static void CreateAllDictionaryEntities()
        {
            AirplaneSchema.Create(StubsObjects.AirplaneSchema.ToEntity());
            AirplaneSubType.Create(StubsObjects.AirplaneSubType.ToEntity());
            AirplaneType.Create(StubsObjects.AirplaneType.ToEntity());
            ClassType.Create(StubsObjects.ClassType.ToEntity());
            Country.Create(StubsObjects.Country.ToEntity());
            DocumentType.Create(StubsObjects.DocumentType.ToEntity());
            OrderStatus.Create(StubsObjects.OrderStatus.ToEntity());
            UserRole.Create(StubsObjects.UserRole.ToEntity());
        }

        public static void DeleteAllDictionaryEntities()
        {
            AirplaneSchema.Delete(StubsObjects.AirplaneSchema.Id);
            AirplaneSubType.Delete(StubsObjects.AirplaneSubType.Id);
            AirplaneType.Delete(StubsObjects.AirplaneType.Id);
            ClassType.Delete(StubsObjects.ClassType.Id);
            Country.Delete(StubsObjects.Country.Id);
            DocumentType.Delete(StubsObjects.DocumentType.Id);
            OrderStatus.Delete(StubsObjects.OrderStatus.Id);
            UserRole.Delete(StubsObjects.UserRole.Id);
        }


        public static void CreateAllEntities(object o)
        {
            CreateAllDictionaryEntities();

            if (o is Airplane)
            {
                Airline.Create(StubsObjects.Airline.ToEntity());
            }
            else if (o is Flight)
            {
                Airline.Create(StubsObjects.Airline.ToEntity());
                Airplane.Create(StubsObjects.Airplane.ToEntity());
                Airport.Create(StubsObjects.Airport.ToEntity());
            }
            else
            {
                Airline.Create(StubsObjects.Airline.ToEntity());
                Airplane.Create(StubsObjects.Airplane.ToEntity());
                Airport.Create(StubsObjects.Airport.ToEntity());
                Document.Create(StubsObjects.Document.ToEntity());
                Flight.Create(StubsObjects.Flight.ToEntity());
                PassengerSeat.Create(StubsObjects.PassengerSeat.ToEntity());
            }
        }

        public static void DeleteAllEntities(object o)
        {
            

            if (o is Airplane)
            {
                Airline.Delete(StubsObjects.Airline.Id);
            }
            else if (o is Flight)
            {
                Airline.Delete(StubsObjects.Airline.Id);
                Airplane.Delete(StubsObjects.Airplane.Id);
                Airport.Delete(StubsObjects.Airport.Id);
            }
            else
            {
                Airline.Delete(StubsObjects.Airline.Id);
                Airplane.Delete(StubsObjects.Airplane.Id);
                Airport.Delete(StubsObjects.Airport.Id);
                Document.Delete(StubsObjects.Document.Id);
                Flight.Delete(StubsObjects.Flight.Id);
                PassengerSeat.Delete(StubsObjects.PassengerSeat.Id);
            }

            DeleteAllDictionaryEntities();
        }

    }
}
