CREATE PROCEDURE [dbo].[InsertAirplaneSubType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[AirplaneSubTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
