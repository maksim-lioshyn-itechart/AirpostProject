CREATE PROCEDURE [dbo].[UpdateAirport]
    @Id UNIQUEIDENTIFIER,
    @CountryId UNIQUEIDENTIFIER,
    @Name NVARCHAR (300),
    @IsActive BIT
AS
BEGIN
    UPDATE [dbo].[Airports]
    SET
        [CountryId] = @CountryId,
        [Name] = @Name,
        [IsActive] = @IsActive
    WHERE Id = @Id
END
GO
