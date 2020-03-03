CREATE PROCEDURE [dbo].[GetPassengerSeatsBy]
    @AirplaneSchemaId UNIQUEIDENTIFIER = NULL,
    @ClassTypeId UNIQUEIDENTIFIER = NULL,
    @Sector NVARCHAR(2) = NULL,
    @Floor INT = NULL,
    @Row INT = NULL,
    @Seat INT = NULL,
    @CoordinateX1 INT = NULL,
    @CoordinateY1 INT = NULL,
    @CoordinateX2 INT = NULL,
    @CoordinateY2 INT = NULL
AS
BEGIN
    SELECT [Id], [AirplaneSchemaId], [ClassTypeId], [Sector], [Floor], [Row], [Seat], [CoordinateX1], [CoordinateY1], [CoordinateX2], [CoordinateY2]
    FROM [dbo].[PassengerSeats]
    WHERE [AirplaneSchemaId] = COALESCE(@AirplaneSchemaId, [AirplaneSchemaId])
        AND [ClassTypeId] = COALESCE(@ClassTypeId, [ClassTypeId])
        AND [Sector] = COALESCE(@Sector, [Sector])
        AND [Floor] = COALESCE(@Floor, [Floor])
        AND [Row] = COALESCE(@Row, [Row])
        AND [Seat] = COALESCE(@Seat, [Seat])
        AND [CoordinateX1] = COALESCE(@CoordinateX1, [CoordinateX1])
        AND [CoordinateY1] = COALESCE(@CoordinateY1, [CoordinateY1])
        AND [CoordinateX2] = COALESCE(@CoordinateX2, [CoordinateX2])
        AND [CoordinateY2] = COALESCE(@CoordinateY2, [CoordinateY2])
END
GO
