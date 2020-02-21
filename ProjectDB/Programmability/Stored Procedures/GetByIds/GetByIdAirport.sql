CREATE PROCEDURE [dbo].[GetByIdAirport]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
    WHERE Id = @Id
END
GO
