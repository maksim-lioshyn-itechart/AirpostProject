CREATE PROCEDURE [dbo].[GetAllFlights]
AS
BEGIN
    Select [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
END
GO
