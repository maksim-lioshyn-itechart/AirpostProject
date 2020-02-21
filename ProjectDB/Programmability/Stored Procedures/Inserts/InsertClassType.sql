CREATE PROCEDURE [dbo].[InsertClassType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[ClassTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
