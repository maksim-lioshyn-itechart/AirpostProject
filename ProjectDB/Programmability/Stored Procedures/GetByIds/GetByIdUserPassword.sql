CREATE PROCEDURE [dbo].[GetByIdUserPassword]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [UserId], [Salt], [Hash]
    FROM [dbo].[UserPasswords]
    WHERE Id = @Id
END
GO
