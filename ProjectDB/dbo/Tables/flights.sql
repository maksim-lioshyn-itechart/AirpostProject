CREATE TABLE [dbo].[Flights] (
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Flights_Id] DEFAULT (newid()) NOT NULL,
    [DepartureAirportId] UNIQUEIDENTIFIER NOT NULL,
    [DestinationAirportId] UNIQUEIDENTIFIER NOT NULL,
    [DepartureTimeUTC] DATETIME NOT NULL,
    [ArrivalTimeUTC] DATETIME NOT NULL,
    [AirplaneId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Flights_Airplanes] FOREIGN KEY ([AirplaneId]) REFERENCES [dbo].[Airplanes] ([Id]),
    CONSTRAINT [FK_Raises_DepartureAirport] FOREIGN KEY ([DepartureAirportId]) REFERENCES [dbo].[Airports] ([Id]),
    CONSTRAINT [FK_Raises_DestinationAirport] FOREIGN KEY ([DestinationAirportId]) REFERENCES [dbo].[Airports] ([Id])
);


