CREATE TABLE [dbo].[Tickets]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Tickets_Id] DEFAULT (newid()) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL, 
	[OrderStatusId] UNIQUEIDENTIFIER NOT NULL, 
    [RaiseId] UNIQUEIDENTIFIER NOT NULL, 
	[PassengerSeatId] UNIQUEIDENTIFIER NOT NULL, 
	[DocumentId] UNIQUEIDENTIFIER NOT NULL, 
    [TicketNumber] NVARCHAR(20) NOT NULL, 
    [DateOfPurchase] DATETIME NOT NULL, 
    [Baggage] INT NOT NULL DEFAULT 0, 
    [Cost] MONEY NOT NULL, 
    [Taxes] MONEY NOT NULL DEFAULT 0, 
    [FreeWeightCapacity] DECIMAL NOT NULL DEFAULT 0, 
    [OverWeightPrice] MONEY NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tickets_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Tickets_Raise] FOREIGN KEY ([RaiseId]) REFERENCES [Flights]([Id]),
    CONSTRAINT [FK_Tickets_PassengerSeats] FOREIGN KEY ([PassengerSeatId]) REFERENCES [PassengerSeats]([Id]),
    CONSTRAINT [FK_Tickets_OrderStatuses] FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatuses]([Id]),
    CONSTRAINT [FK_Tickets_Documents] FOREIGN KEY ([DocumentId]) REFERENCES [Documents] ([Id])
)
