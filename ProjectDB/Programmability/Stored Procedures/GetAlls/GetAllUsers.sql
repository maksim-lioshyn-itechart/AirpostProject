CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SELECT [Id], [FirstName], [LastName], [Email], [RoleId], [Phone], [Address]
    FROM [dbo].[Users]
END
GO
