CREATE PROCEDURE [dbo].[GetAllOrderStatus]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[OrderStatuses]
END
GO
