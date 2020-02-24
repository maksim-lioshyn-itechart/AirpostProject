CREATE PROCEDURE [dbo].[GetUserPasswordById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [UserId], [Salt], [Hash]
    FROM [dbo].[UserPasswords]
    WHERE Id = @Id
END
GO
