CREATE PROCEDURE [dbo].[UpdateCountry]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (150),
    @Code NVARCHAR (4)
AS
BEGIN
    UPDATE [dbo].[Countries]
    SET
        [Name] = @Name,
        [Code] = @Code
    WHERE Id = @Id
END
GO
