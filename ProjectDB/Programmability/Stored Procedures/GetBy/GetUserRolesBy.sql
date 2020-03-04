CREATE PROCEDURE [dbo].[GetUserRolesBy]
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[UserRoles]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
