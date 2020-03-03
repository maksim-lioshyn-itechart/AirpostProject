CREATE PROCEDURE [dbo].[GetUserBy]
    @Email NVARCHAR(256),
    @Phone NVARCHAR(16)
AS
BEGIN
    SELECT [Id], [FirstName], [LastName], [Email], [RoleId], [Phone], [Address]
    FROM [dbo].[Users]
    WHERE [Email] = COALESCE(@Email, [Email]) 
        AND [Phone] = COALESCE(@Phone, [Phone]) 
END
GO
