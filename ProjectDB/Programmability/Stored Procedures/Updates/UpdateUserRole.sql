CREATE PROCEDURE [dbo].[UpdateUserRole]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (50)
AS
BEGIN
    UPDATE [dbo].[UserRoles]
    SET
        [Name] = @Name
WHERE Id = @Id
END
GO
