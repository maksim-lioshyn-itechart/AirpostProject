CREATE PROCEDURE [dbo].[GetAllUserPassword]
AS
BEGIN
    Select [Id], [UserId], [Salt], [Hash]
    FROM [dbo].[UserPasswords]
END
GO
