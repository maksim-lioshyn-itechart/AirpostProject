CREATE TABLE [dbo].[AirplaneSchemas] (
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_AirplaneSchemas_Id] DEFAULT (newid()) NOT NULL,
    [SeatsNumber] INT NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AirplaneSchemas] PRIMARY KEY CLUSTERED ([Id] ASC)
);


