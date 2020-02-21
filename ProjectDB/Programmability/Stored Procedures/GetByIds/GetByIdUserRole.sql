CREATE PROCEDURE [dbo].[GetByIdUserRole]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[UserRoles]
    WHERE Id = @Id
END
GO
