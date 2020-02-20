CREATE TABLE [dbo].[Airports] (
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Airports_Id] DEFAULT (newid()) NOT NULL,
    [CountryId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (300)   NOT NULL,
    [IsActive] BIT CONSTRAINT [DF_Airports_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Airports_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
);

