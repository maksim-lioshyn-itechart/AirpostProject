CREATE PROCEDURE [dbo].[UpdateOrderStatuse]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(10)
AS
BEGIN
    UPDATE [dbo].[OrderStatuses]
    SET
        [Name] = @Name
WHERE Id = @Id
END
GO
