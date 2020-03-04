CREATE PROCEDURE [dbo].[GetAirplaneById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity], [SerialNumber]
    FROM [dbo].[Airplanes]
    WHERE Id = @Id
END
GO
