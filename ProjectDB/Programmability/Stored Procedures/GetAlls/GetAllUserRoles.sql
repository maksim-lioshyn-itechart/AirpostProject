CREATE PROCEDURE [dbo].[GetAllUserRoles]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[UserRoles]
END
GO
