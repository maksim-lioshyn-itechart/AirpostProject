CREATE PROCEDURE [dbo].[SpInsertOrderStatus]
    @Name NVARCHAR (10),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[OrderStatuses] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO