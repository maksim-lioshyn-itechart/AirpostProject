CREATE PROCEDURE [dbo].[GetOrderStatusesBy]
    @Name NVARCHAR(10) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[OrderStatuses]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
