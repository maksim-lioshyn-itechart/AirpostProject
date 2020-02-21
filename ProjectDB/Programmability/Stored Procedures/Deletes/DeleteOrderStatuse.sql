CREATE PROCEDURE [dbo].[DeleteOrderStatus]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[OrderStatuses] WHERE Id = @Id
END
GO
