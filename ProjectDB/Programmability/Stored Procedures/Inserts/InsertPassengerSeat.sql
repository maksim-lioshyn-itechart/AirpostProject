CREATE PROCEDURE [dbo].[InsertPassengerSeat]
    @Id UNIQUEIDENTIFIER,
    @AirplaneSchemaId UNIQUEIDENTIFIER,
    @ClassTypeId UNIQUEIDENTIFIER,
    @Sector NVARCHAR(2),
    @Floor INT,
    @Row INT,
    @Seat INT,
    @CoordinateX1 INT,
    @CoordinateY1 INT,
    @CoordinateX2 INT,
    @CoordinateY2 INT
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[PassengerSeats] ([Id], [AirplaneSchemaId], [ClassTypeId], [Sector], [Floor], [Row], [Seat], [CoordinateX1], [CoordinateY1], [CoordinateX2], [CoordinateY2])
    VALUES(@Id, @AirplaneSchemaId, @ClassTypeId, @Sector, @Floor, @Row, @Seat, @CoordinateX1, @CoordinateY1, @CoordinateX2, @CoordinateY2)
END
GO
