CREATE PROCEDURE [dbo].[GetByCountryIdAirline]
    @CountryId UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
    WHERE CountryId = @CountryId
END
GO
