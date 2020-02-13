CREATE TABLE [dbo].[Tickets]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Tickets_Id] DEFAULT (newid()) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NULL, 
    [RaiseId] UNIQUEIDENTIFIER NOT NULL, 
    [TicketNumber] NVARCHAR(20) NOT NULL, 
    [Document] NVARCHAR(100) NOT NULL, 
    [DateOfPurchase] DATETIME NOT NULL, 
    [ClassTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [Baggage] INT NOT NULL DEFAULT 0, 
    [Fare] MONEY NOT NULL, 
    [Taxes] MONEY NOT NULL DEFAULT 0, 
    [Charge] MONEY NOT NULL DEFAULT 0, 
    [FreeWeightCapacity] DECIMAL NOT NULL DEFAULT 0, 
    [OverWeightPrice] MONEY NOT NULL DEFAULT 0, 
    [Seat] NVARCHAR(5) NOT NULL, 
    [OrderStatusId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tickets_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Tickets_Raise] FOREIGN KEY ([RaiseId]) REFERENCES [Flights]([Id]),
    CONSTRAINT [FK_Tickets_ClassTypes] FOREIGN KEY ([ClassTypeId]) REFERENCES [ClassTypes]([Id]),
    CONSTRAINT [FK_Tickets_OrderStatuses] FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatuses]([Id])    
)
