CREATE PROCEDURE [dbo].[GetFlightById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
    WHERE Id = @Id
END
GO
