CREATE PROCEDURE [dbo].[InsertUserPassword]
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Salt BINARY(16),
    @Hash BINARY(32)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[UserPasswords] ([Id], [UserId], [Salt], [Hash])
    VALUES(@Id, @UserId, @Salt, @Hash)
END
GO
