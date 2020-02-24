CREATE PROCEDURE [dbo].[GetAllOrderStatuses]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[OrderStatuses]
END
GO
