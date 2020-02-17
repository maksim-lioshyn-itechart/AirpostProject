CREATE TABLE [dbo].[DocumentTypes]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_DocumentTypes_Id] DEFAULT (newid()) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
)
