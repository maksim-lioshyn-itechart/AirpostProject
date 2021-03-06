CREATE PROCEDURE [dbo].[UpdateAirline]
    @Id UNIQUEIDENTIFIER,
    @CountryId UNIQUEIDENTIFIER,
    @Name NVARCHAR(50),
    @Email NVARCHAR(256),
    @Phone NVARCHAR(50),
    @Address NVARCHAR(400),
    @URL NVARCHAR(400)
AS
BEGIN
    UPDATE [dbo].[Airlines]
    SET
        [CountryId] = @CountryId,
        [Name] = @Name,
        [Email] = @Email,
        [Phone] = @Phone,
        [Address] = @Address,
        [URL] = @URL
    WHERE Id = @Id
END
GO
