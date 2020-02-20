CREATE PROCEDURE [dbo].[SpInsertAirplaneType]
    @Name NVARCHAR (50),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[AirplaneTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO