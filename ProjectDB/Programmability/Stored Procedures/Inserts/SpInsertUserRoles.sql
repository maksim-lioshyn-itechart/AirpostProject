CREATE PROCEDURE [dbo].[SpInsertUserRoles]
    @Name NVARCHAR (50),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[UserRoles] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
