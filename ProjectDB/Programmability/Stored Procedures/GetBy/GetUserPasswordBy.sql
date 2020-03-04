CREATE PROCEDURE [dbo].[GetUserPasswordBy]
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [UserId], [Salt], [Hash]
    FROM [dbo].[UserPasswords]
    WHERE UserId = @UserId
END
GO
