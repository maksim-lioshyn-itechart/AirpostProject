namespace DataAccessLayer
{
    public static class Queries
    {
        public const string insertAirlines =
            @"INSERT INTO Airlines(Name, Email, Phone, Address, Url, Id) 
                     VALUES(@Name, @Email, @Phone, @Address, @Url, @Id)";

        public const string insertAirplanes =
            @"INSERT INTO Airplanes(Name, AirplaneTypeId, AirplaneSubTypeId, CarryingCapacity, AirlineId, AirplaneSchemaId, Id) 
                     VALUES(@Name, @AirplaneTypeId, @AirplaneSubTypeId, @CarryingCapacity, @AirlineId, @AirplaneSchemaId, @Id)";

        public const string insertAirplaneSchemas =
            @"INSERT INTO AirplaneSchemas(NumberOfSeats, Code, Id) 
                     VALUES(@NumberOfSeats, @Code, @Id)";

        public const string insertAirplaneSubTypes =
            @"INSERT INTO AirplaneSubTypes(Name, AirplaneTypeId, Id) VALUES(@Name, @AirplaneTypeId, @Id)";

        public const string insertAirplaneTypes =
            @"INSERT INTO AirplaneTypes(Name, Id) VALUES(@Name, @Id)";

        public const string insertAirports =
            @"INSERT INTO Airports(Name, IsActive, CountryId, Id) VALUES(@Name, @IsActive, @CountryId, @Id)";
      
        public const string insertClassTypes =
            @"INSERT INTO ClassTypes(Name, Id) VALUES(@Name, @Id)";

        public const string insertCountries =
            @"INSERT INTO Countris(Name, Code, Id) VALUES(@Name, @Code, @Id)";

        public const string insertFlights =
            @"INSERT INTO Flights(DepartureAirportId, DestinationAirportId, DepartureTimeUtc, ArrivalTimeUtc, AirplaneId, Id) 
                     VALUES(@DepartureAirportId, @DestinationAirportId, @DepartureTimeUtc, @ArrivalTimeUtc, @AirplaneId, @Id)";

        public const string insertOrderStatuses =
            @"INSERT INTO OrderStatuses(Name, Id) VALUES(@Name, @Id)";

        public const string insertPassengerSeatTemplates =
            @"INSERT INTO PassengerSeatTemplates(Type, Code, CoordinateX1, CoordinateY1, CoordinateX2, CoordinateY2, Id) 
                     VALUES(@Type, @Code, @CoordinateX1, @CoordinateY1, @CoordinateX2, @CoordinateY2, @Id)";

        public const string insertSchemasPassengerSeatTemplates =
            @"INSERT INTO SchemasPassengerSeatTemplates(PassengerSeatTemplateId, SchemaId) 
                     VALUES(@PassengerSeatTemplateId, @SchemaId)";
                     
        public const string insertTickets =    
                     @"INSERT INTO Tickets(UserId, RaiseId, TicketNumber, Document, DateOfPurchase, ClassTypeId, Baggage, 
                                           Fare, Taxes, Charge, FreeWeightCapacity, OverWeightPrice, Seat, OrderStatusId, Id) 
                              VALUES(@UserId, @RaiseId, @TicketNumber, @Document, @DateOfPurchase, @ClassTypeId, @Baggage, 
                                     @Fare, @Taxes, @Charge, @FreeWeightCapacity, @OverWeightPrice, @Seat, @OrderStatusId, @Id)";

        public const string insertUsers =
            @"INSERT INTO Users(FirstName, LastName, Email, Password, RoleId, Phone, Address, Id) 
                     VALUES(@FirstName, @LastName, @Email, @Password, @RoleId, @Phone, @Address, @Id)";

        public const string insertUserRoles =
            @"INSERT INTO UserRoles(Name, Id) VALUES(@Name, @Id)";
    }
}
