CREATE PROCEDURE [dbo].[UpdatePassengerSeat]
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
    UPDATE [dbo].[PassengerSeats]
    SET
        [AirplaneSchemaId] = @AirplaneSchemaId,
        [ClassTypeId] = @ClassTypeId,
        [Sector] = @Sector,
        [Floor] = @Floor,
        [Row] = @Row,
        [Seat] = @Seat,
        [CoordinateX1] = @CoordinateX1,
        [CoordinateY1] = @CoordinateY1,
        [CoordinateX2] = @CoordinateX2,
        [CoordinateY2] = @CoordinateY2
WHERE Id = @Id
END
GO
