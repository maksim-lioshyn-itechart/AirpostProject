CREATE PROCEDURE [dbo].[GetAirplaneBy]
    @Id UNIQUEIDENTIFIER = NULL,
    @AirplaneSubTypeId UNIQUEIDENTIFIER = NULL,
    @AirplaneTypeId UNIQUEIDENTIFIER = NULL,
    @AirplaneSchemaId UNIQUEIDENTIFIER = NULL,
    @AirlineId UNIQUEIDENTIFIER = NULL,
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity]
    FROM [dbo].[Airplanes]
    WHERE Id = COALESCE(@Id, [Id]) 
        AND [AirlineId] = COALESCE(@AirlineId, [AirlineId])
        AND [AirplaneSubTypeId] = COALESCE(@AirplaneSubTypeId, [AirplaneSubTypeId])
        AND [AirplaneTypeId] = COALESCE(@AirplaneTypeId, [AirplaneTypeId])
        AND [AirplaneSchemaId] = COALESCE(@AirplaneSchemaId, [AirplaneSchemaId])
        AND [Name] = COALESCE(@Name, [Name])
END
GO
