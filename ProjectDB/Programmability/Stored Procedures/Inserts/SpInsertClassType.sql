CREATE PROCEDURE [dbo].[SpInsertClassType]
    @Name NVARCHAR (50),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[ClassTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO