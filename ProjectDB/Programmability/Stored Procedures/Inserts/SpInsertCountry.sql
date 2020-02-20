CREATE PROCEDURE [dbo].[SpInsertCountry]
    @Name NVARCHAR (150),
    @Code NVARCHAR (4),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[Countries] ([Id], [Name], [Code])
    VALUES(@Id, @Name, @Code)
END
GO