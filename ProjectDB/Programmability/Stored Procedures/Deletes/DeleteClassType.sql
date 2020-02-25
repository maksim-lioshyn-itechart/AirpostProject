CREATE PROCEDURE [dbo].[DeleteClassType]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[ClassTypes] WHERE Id = @Id
END
GO
