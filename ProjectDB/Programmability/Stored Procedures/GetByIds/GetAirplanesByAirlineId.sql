CREATE PROCEDURE [dbo].[GetAirplanesByAirlineId]
    @AirlineId UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE AirlineId = @AirlineId
END
GO
