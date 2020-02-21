CREATE PROCEDURE [dbo].[InsertClassType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[ClassTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
