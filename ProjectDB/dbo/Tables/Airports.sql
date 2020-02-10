CREATE TABLE [dbo].[Airports] (
    [id]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (MAX)   NOT NULL,
    [IsActive]  BIT              CONSTRAINT [DF_Airports_IsActive] DEFAULT ((0)) NULL,
    [CountryId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Airports_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

