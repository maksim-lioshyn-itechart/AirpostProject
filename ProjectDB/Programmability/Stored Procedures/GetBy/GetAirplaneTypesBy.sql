CREATE PROCEDURE [dbo].[GetAirplaneTypesBy]
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneTypes]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
