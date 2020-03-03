CREATE PROCEDURE [dbo].[GetCountriesBy]
    @Name NVARCHAR(150) = NULL
AS
BEGIN
    SELECT [Id], [Name], [Code]
    FROM [dbo].[Countries]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
