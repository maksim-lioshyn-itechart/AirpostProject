CREATE PROCEDURE [dbo].[InsertUser]
    @Id UNIQUEIDENTIFIER,
    @FirstName NVARCHAR (300),
    @LastName NVARCHAR (300),
    @Email NVARCHAR (256),
    @RoleId UNIQUEIDENTIFIER,
    @Phone NVARCHAR (50),
    @Address NVARCHAR (400)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [RoleId], [Phone], [Address])
    VALUES(@Id, @FirstName, @LastName, @Email, @RoleId, @Phone, @Address)
END
GO
