CREATE PROCEDURE [dbo].[InsertAirport]
    @Id UNIQUEIDENTIFIER,
    @CountryId UNIQUEIDENTIFIER,
    @Name NVARCHAR (300),
    @IsActive BIT
AS
BEGIN
    INSERT INTO [dbo].[Airports] ([Id], [CountryId], [Name], [IsActive])
    VALUES(@Id, @CountryId, @Name, @IsActive)
END
GO
