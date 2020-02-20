CREATE TABLE [dbo].[PassengerSeats]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_PassengerSeats_Id] DEFAULT (newid()) NOT NULL,
    [AirplaneSchemaId] UNIQUEIDENTIFIER NOT NULL, 
    [ClassTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [Sector] NVARCHAR(2) NULL, 
    [Floor] INT NULL ,
    [Row] INT NOT NULL, 
    [Seat] INT NOT NULL, 
    [CoordinateX1] INT NOT NULL, 
    [CoordinateY1] INT NOT NULL,
    [CoordinateX2] INT NOT NULL, 
    [CoordinateY2] INT NOT NULL, 
    CONSTRAINT [PK_PassengerSeats] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PassengerSeats_ClassTypes] FOREIGN KEY ([ClassTypeId]) REFERENCES [ClassTypes]([Id]),
    CONSTRAINT [FK_PassengerSeats_AirplaneSchemas] FOREIGN KEY ([AirplaneSchemaId]) REFERENCES [AirplaneSchemas] ([Id])
)
