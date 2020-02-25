CREATE PROCEDURE [dbo].[GetAirplanesByAirlineId]
    @AirlineId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE AirlineId = @AirlineId
END
GO
