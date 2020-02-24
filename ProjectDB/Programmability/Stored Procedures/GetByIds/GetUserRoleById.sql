CREATE PROCEDURE [dbo].[GetUserRoleById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[UserRoles]
    WHERE Id = @Id
END
GO
