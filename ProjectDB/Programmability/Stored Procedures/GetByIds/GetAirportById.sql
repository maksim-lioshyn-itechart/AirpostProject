CREATE PROCEDURE [dbo].[GetAirportById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
    WHERE Id = @Id
END
GO
