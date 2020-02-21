CREATE PROCEDURE [dbo].[GetAllAirplane]
AS
BEGIN
    Select [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
END
GO
