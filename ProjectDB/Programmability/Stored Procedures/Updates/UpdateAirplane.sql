CREATE PROCEDURE [dbo].[UpdateAirplane]
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
    UPDATE [dbo].[Airplanes]
    SET
        [AirplaneSubTypeId] = @AirplaneSubTypeId,
        [AirplaneTypeId] = @AirplaneTypeId,
        [AirplaneSchemaId] = @AirplaneSchemaId,
        [AirlineId] = @AirlineId,
        [Name] = @Name,
        [SerialNumber] = @SerialNumber,
        [CarryingCapacity] = @CarryingCapacity
    WHERE Id = @Id
END
GO
