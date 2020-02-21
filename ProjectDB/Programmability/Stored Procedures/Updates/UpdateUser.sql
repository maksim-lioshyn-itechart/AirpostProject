CREATE PROCEDURE [dbo].[UpdateUser]
    @Id UNIQUEIDENTIFIER,
    @FirstName NVARCHAR (300),
    @LastName NVARCHAR (300),
    @Email NVARCHAR (256),
    @RoleId UNIQUEIDENTIFIER,
    @Phone NVARCHAR (50),
    @Address NVARCHAR (400)
AS
BEGIN
    UPDATE [dbo].[Users]
    SET
        [FirstName] = @FirstName,
        [LastName] = @LastName,
        [Email] = @Email,
        [RoleId] = @RoleId,
        [Phone] = @Phone,
        [Address] = @Address
    WHERE Id = @Id
END
GO
