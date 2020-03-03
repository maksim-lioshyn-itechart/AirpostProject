CREATE PROCEDURE [dbo].[GetAirplaneBy]
    @Id UNIQUEIDENTIFIER = NULL,
    @AirlineId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SELECT [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE Id = COALESCE(@Id, [Id]) 
        AND [AirlineId] = COALESCE(@AirlineId, [AirlineId])
END
GO
