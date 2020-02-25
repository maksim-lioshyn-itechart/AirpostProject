CREATE PROCEDURE [dbo].[GetOrderStatusById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[OrderStatuses]
    WHERE Id = @Id
END
GO
