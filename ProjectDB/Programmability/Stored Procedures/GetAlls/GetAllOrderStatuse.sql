CREATE PROCEDURE [dbo].[GetAllOrderStatuse]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[OrderStatuses]
END
GO
