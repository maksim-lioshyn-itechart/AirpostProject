CREATE PROCEDURE [dbo].[GetAirlineBy]
    @CountryId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SELECT [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
    WHERE CountryId = @CountryId
END
GO
