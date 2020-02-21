CREATE PROCEDURE [dbo].[UpdateClassType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[ClassTypes]
    SET
        [Name] = @Name
WHERE Id = @Id
END
GO
