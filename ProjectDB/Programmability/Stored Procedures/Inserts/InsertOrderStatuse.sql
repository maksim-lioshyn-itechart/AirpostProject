CREATE PROCEDURE [dbo].[InsertOrderStatus]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(10)
AS
BEGIN
    INSERT INTO [dbo].[OrderStatuses] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
