CREATE PROCEDURE [dbo].[UpdateUserPassword]
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @Salt BINARY(16),
    @Hash BINARY(32)
AS
BEGIN
    UPDATE [dbo].[UserPasswords]
    SET
        [UserId] = @UserId,
        [Salt] = @Salt,
        [Hash] = @Hash
    WHERE Id = @Id
END
GO
