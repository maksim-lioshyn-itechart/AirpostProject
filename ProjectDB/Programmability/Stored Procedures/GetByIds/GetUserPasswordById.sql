CREATE PROCEDURE [dbo].[GetUserPasswordById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [UserId], [Salt], [Hash]
    FROM [dbo].[UserPasswords]
    WHERE Id = @Id
END
GO
