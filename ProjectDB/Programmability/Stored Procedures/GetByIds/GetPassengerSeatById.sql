CREATE PROCEDURE [dbo].[GetPassengerSeatById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [AirplaneSchemaId], [ClassTypeId], [Sector], [Floor], [Row], [Seat], [CoordinateX1], [CoordinateY1], [CoordinateX2], [CoordinateY2]
    FROM [dbo].[PassengerSeats]
    WHERE Id = @Id
END
GO
