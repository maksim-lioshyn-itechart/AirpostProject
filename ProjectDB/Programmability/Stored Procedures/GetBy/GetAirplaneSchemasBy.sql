CREATE PROCEDURE [dbo].[GetAirplaneSchemasBy]
    @Id UNIQUEIDENTIFIER = NULL,
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
    WHERE Id = COALESCE(@Id, [Id]) 
        AND [Name] = COALESCE(@Name, [Name])
END
GO
