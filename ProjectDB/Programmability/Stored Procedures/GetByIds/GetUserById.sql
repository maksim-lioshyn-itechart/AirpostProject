CREATE PROCEDURE [dbo].[GetUserById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [FirstName], [LastName], [Email], [RoleId], [Phone], [Address]
    FROM [dbo].[Users]
    WHERE Id = @Id
END
GO
