CREATE PROCEDURE [dbo].[GetByIdPassengerSeat]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [AirplaneSchemaId], [ClassTypeId], [Sector], [Floor], [Row], [Seat], [CoordinateX1], [CoordinateY1], [CoordinateX2], [CoordinateY2]
    FROM [dbo].[PassengerSeats]
    WHERE Id = @Id
END
GO
