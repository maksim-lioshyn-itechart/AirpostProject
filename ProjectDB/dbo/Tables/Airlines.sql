CREATE TABLE [dbo].[Airlines]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Airlines_Id] DEFAULT (newid()) NOT NULL,
    [CountryId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
    [Phone] NVARCHAR(16) NOT NULL, 
    [Address] NVARCHAR(400) NOT NULL, 
    [URL] NVARCHAR(200) NOT NULL, 
    CONSTRAINT [PK_Airlines] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Airlines_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
)
