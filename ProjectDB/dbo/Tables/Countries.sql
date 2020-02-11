CREATE TABLE [dbo].[Countries] (
    [id]   UNIQUEIDENTIFIER NOT NULL DEFAULT (newsequentialid()),
    [Name] NVARCHAR (150) UNIQUE NOT NULL,
    [Code] NVARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_CountriesName] UNIQUE ([Name] ASC)
);

