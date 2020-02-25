CREATE PROCEDURE [dbo].[GetAllUserPassword]
AS
BEGIN
    SELECT [Id], [UserId], [Salt], [Hash]
    FROM [dbo].[UserPasswords]
END
GO
