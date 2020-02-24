CREATE PROCEDURE [dbo].[GetAllAirplanes]
AS
BEGIN
    Select [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
END
GO
