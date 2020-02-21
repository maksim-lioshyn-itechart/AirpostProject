CREATE PROCEDURE [dbo].[GetAllFlight]
AS
BEGIN
    Select [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
END
GO
