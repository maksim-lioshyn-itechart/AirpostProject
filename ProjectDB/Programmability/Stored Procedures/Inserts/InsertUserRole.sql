CREATE PROCEDURE [dbo].[InsertUserRole]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (50)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[UserRoles] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
