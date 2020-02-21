CREATE PROCEDURE [dbo].[DeleteUserPassword]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[UserPasswords] WHERE Id = @Id
END
GO
