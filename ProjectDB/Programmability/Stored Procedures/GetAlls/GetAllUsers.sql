CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    Select [Id], [FirstName], [LastName], [Email], [RoleId], [Phone], [Address]
    FROM [dbo].[Users]
END
GO
