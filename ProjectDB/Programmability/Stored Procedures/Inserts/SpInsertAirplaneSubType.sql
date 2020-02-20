CREATE PROCEDURE [dbo].[SpInsertAirplaneSubType]
    @Name NVARCHAR (50),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[AirplaneSubTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO