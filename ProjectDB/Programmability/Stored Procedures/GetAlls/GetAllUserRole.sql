CREATE PROCEDURE [dbo].[GetAllUserRole]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[UserRoles]
END
GO
