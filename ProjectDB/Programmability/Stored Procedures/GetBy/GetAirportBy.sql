CREATE PROCEDURE [dbo].[GetAirportBy]
    @CountryId UNIQUEIDENTIFIER = NULL,
    @Name NVARCHAR(300) = NULL
AS
BEGIN
    SELECT [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
    WHERE [CountryId] = COALESCE(@CountryId, [CountryId])
        AND [Name] = COALESCE(@Name, [Name])
END
GO
