CREATE PROCEDURE [dbo].[GetUserRoleById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[UserRoles]
    WHERE Id = @Id
END
GO
