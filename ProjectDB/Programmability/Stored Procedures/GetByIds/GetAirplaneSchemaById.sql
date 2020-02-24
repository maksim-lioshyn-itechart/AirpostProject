CREATE PROCEDURE [dbo].[GetAirplaneSchemaById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
    WHERE Id = @Id
END
GO
