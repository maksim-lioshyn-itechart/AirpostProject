CREATE PROCEDURE [dbo].[SpInsertAirline]
    @Name NVARCHAR (50),
    @Email NVARCHAR (256),
    @Phone NVARCHAR (50),
    @Address NVARCHAR (400),
    @URL NVARCHAR (400),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[Airlines] ([Id], [Name], [Email], [Phone], [Address], [URL])
    VALUES(@Id, @Name, @Email, @Phone, @Address, @URL)
END
GO