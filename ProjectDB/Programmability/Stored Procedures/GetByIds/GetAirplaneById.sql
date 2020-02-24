CREATE PROCEDURE [dbo].[GetAirplaneById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE Id = @Id
END
GO
