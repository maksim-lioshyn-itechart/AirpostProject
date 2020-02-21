CREATE PROCEDURE [dbo].[GetByIdOrderStatus]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[OrderStatuses]
    WHERE Id = @Id
END
GO
