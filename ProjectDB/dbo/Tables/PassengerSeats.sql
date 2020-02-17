CREATE TABLE [dbo].[PassengerSeats]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_PassengerSeats_Id] DEFAULT (newid()) NOT NULL,
    [PassengerSeatTemplateId] UNIQUEIDENTIFIER NOT NULL, 
	[ClassTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [Sector] NVARCHAR(2) NULL, 
    [Floor] INT NULL ,
    [Row] INT NOT NULL DEFAULT 1, 
    [Seat] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_PassengerSeats] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PassengerSeats_ClassTypes] FOREIGN KEY ([ClassTypeId]) REFERENCES [ClassTypes]([Id]),
    CONSTRAINT [FK_PassengerSeats_PassengerSeatTemplates] FOREIGN KEY ([PassengerSeatTemplateId]) REFERENCES [PassengerSeatTemplates] ([Id])
)
