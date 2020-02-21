CREATE PROCEDURE [dbo].[InsertAirline]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50),
    @Email NVARCHAR(256),
    @Phone NVARCHAR(50),
    @Address NVARCHAR(400),
    @URL NVARCHAR(400)
AS
BEGIN
    INSERT INTO [dbo].[Airlines] ([Id], [Name], [Email], [Phone], [Address], [URL])
    VALUES(@Id, @Name, @Email, @Phone, @Address, @URL)
END
GO
