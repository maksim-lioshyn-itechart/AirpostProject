CREATE PROCEDURE [dbo].[GetAirplaneSchemaById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
    WHERE Id = @Id
END
GO
