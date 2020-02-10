CREATE TABLE [dbo].[Countries] (
    [id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (MAX)   NOT NULL,
    [Code] NVARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([id] ASC)
);

