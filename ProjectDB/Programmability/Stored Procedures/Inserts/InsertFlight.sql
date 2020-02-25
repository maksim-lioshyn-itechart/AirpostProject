CREATE PROCEDURE [dbo].[InsertFlight]
    @Id UNIQUEIDENTIFIER,
    @DepartureAirportId UNIQUEIDENTIFIER,
    @DestinationAirportId UNIQUEIDENTIFIER,
    @DepartureTimeUTC DATETIME,
    @ArrivalTimeUTC DATETIME,
    @AirplaneId UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO [dbo].[Flights] ([Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId])
    VALUES(@Id, @DepartureAirportId, @DestinationAirportId, @DepartureTimeUTC, @ArrivalTimeUTC, @AirplaneId)
END
GO
