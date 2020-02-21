CREATE PROCEDURE [dbo].[InsertCountry]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (150),
    @Code NVARCHAR (4)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[Countries] ([Id], [Name], [Code])
    VALUES(@Id, @Name, @Code)
END
GO
