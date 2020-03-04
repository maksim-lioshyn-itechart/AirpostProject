CREATE PROCEDURE [dbo].[GetAllAirplanes]
AS
BEGIN
    SELECT [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity], [SerialNumber]
    FROM [dbo].[Airplanes]
END
GO
