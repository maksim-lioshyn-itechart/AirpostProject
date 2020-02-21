CREATE PROCEDURE [dbo].[InsertUserRole]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (50)
AS
BEGIN
    INSERT INTO [dbo].[UserRoles] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
