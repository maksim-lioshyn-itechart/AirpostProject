CREATE PROCEDURE [dbo].[DeleteTicket]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[Tickets] WHERE Id = @Id
END
GO
