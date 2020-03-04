CREATE PROCEDURE [dbo].[InsertAirplane]
    @Id UNIQUEIDENTIFIER,
    @AirplaneSubTypeId UNIQUEIDENTIFIER,
    @AirplaneTypeId UNIQUEIDENTIFIER,
    @AirplaneSchemaId UNIQUEIDENTIFIER,
    @AirlineId UNIQUEIDENTIFIER,
    @Name NVARCHAR(50),
    @SerialNumber NVARCHAR(50),
    @CarryingCapacity DECIMAL
AS
BEGIN
    INSERT INTO [dbo].[Airplanes] ([Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity], [SerialNumber])
    VALUES(@Id, @AirplaneSubTypeId, @AirplaneTypeId, @AirplaneSchemaId, @AirlineId, @Name, @CarryingCapacity, @SerialNumber)
END
GO
