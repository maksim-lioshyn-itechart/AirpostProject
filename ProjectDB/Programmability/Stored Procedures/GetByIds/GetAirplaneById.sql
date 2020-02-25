CREATE PROCEDURE [dbo].[GetAirplaneById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE Id = @Id
END
GO
