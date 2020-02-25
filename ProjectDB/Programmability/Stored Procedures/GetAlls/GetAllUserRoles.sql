CREATE PROCEDURE [dbo].[GetAllUserRoles]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[UserRoles]
END
GO
