CREATE TABLE [dbo].[PassengerSeatTemplates]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_PassengerSeatTemplates_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [CoordinateX1] INT NULL, 
    [CoordinateY1] INT NULL,
    [CoordinateX2] INT NULL, 
    [CoordinateY2] INT NULL, 
    CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED ([Id] ASC)
)
