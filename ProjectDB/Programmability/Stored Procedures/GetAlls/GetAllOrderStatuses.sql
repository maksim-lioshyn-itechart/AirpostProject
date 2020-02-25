CREATE PROCEDURE [dbo].[GetAllOrderStatuses]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[OrderStatuses]
END
GO
