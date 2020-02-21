CREATE PROCEDURE [dbo].[GetByIdAirplane]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE Id = @Id
END
GO
