CREATE PROCEDURE [dbo].[GetAllAirplaneSubTypesBy]
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneSubTypes]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
