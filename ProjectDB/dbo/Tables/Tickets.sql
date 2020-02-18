CREATE TABLE [dbo].[Tickets]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Tickets_Id] DEFAULT (newid()) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL, 
	[OrderStatusId] UNIQUEIDENTIFIER NOT NULL, 
    [FlightId] UNIQUEIDENTIFIER NOT NULL, 
	[PassengerSeatId] UNIQUEIDENTIFIER NOT NULL, 
	[DocumentId] UNIQUEIDENTIFIER NOT NULL, 
    [TicketNumber] NVARCHAR(20) NOT NULL, 
    [PurchaseDate] DATETIME NOT NULL, 
    [BaggageCount] INT NOT NULL DEFAULT 0, 
    [Cost] MONEY NOT NULL, 
    [Taxes] MONEY NOT NULL DEFAULT 0, 
    [FreeWeightCapacity] DECIMAL NOT NULL DEFAULT 0, 
    [OverweightPrice] MONEY NOT NULL DEFAULT 0, 
    [Total] MONEY NOT NULL, 
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tickets_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Tickets_Raise] FOREIGN KEY ([FlightId]) REFERENCES [Flights]([Id]),
    CONSTRAINT [FK_Tickets_PassengerSeats] FOREIGN KEY ([PassengerSeatId]) REFERENCES [PassengerSeats]([Id]),
    CONSTRAINT [FK_Tickets_OrderStatuses] FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatuses]([Id]),
    CONSTRAINT [FK_Tickets_Documents] FOREIGN KEY ([DocumentId]) REFERENCES [Documents] ([Id])
)
