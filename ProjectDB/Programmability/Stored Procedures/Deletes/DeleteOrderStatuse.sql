CREATE PROCEDURE [dbo].[DeleteOrderStatuse]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[OrderStatuses] WHERE Id = @Id
END
GO
