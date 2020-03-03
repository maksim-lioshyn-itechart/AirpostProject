CREATE PROCEDURE [dbo].[GetAirlineBy]
    @CountryId UNIQUEIDENTIFIER = NULL,
    @Email NVARCHAR(200) = NULL
AS
BEGIN
    SELECT [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
    WHERE [CountryId] = COALESCE(@CountryId, [CountryId])
        AND [Email] = COALESCE(@Email, [Email])
END
GO
