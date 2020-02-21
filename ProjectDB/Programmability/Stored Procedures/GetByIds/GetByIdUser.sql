CREATE PROCEDURE [dbo].[GetByIdUser]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [FirstName], [LastName], [Email], [RoleId], [Phone], [Address]
    FROM [dbo].[Users]
    WHERE Id = @Id
END
GO
