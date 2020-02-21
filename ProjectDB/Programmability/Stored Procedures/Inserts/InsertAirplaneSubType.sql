CREATE PROCEDURE [dbo].[InsertAirplaneSubType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[AirplaneSubTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
