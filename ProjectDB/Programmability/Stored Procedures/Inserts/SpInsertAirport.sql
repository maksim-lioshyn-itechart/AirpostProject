CREATE PROCEDURE [dbo].[SpInsertAirport]
    @Id UNIQUEIDENTIFIER,
	@CountryId UNIQUEIDENTIFIER,
    @Name NVARCHAR (300),
    @IsActive BIT
AS
BEGIN
    SET @Id = NEWID();
    SET @IsActive = 0;
    INSERT INTO [dbo].[Airports] ([Id], [CountryId], [Name], [IsActive])
    VALUES(@Id, @CountryId, @Name, @IsActive)
END
GO
