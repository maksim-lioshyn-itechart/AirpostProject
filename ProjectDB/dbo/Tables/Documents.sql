CREATE TABLE [dbo].[Documents]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Documents_Id] DEFAULT (newid()) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Number] nvarchar(50) NOT NULL,
    [DocumentTypeId] UNIQUEIDENTIFIER  NOT NULL,
    [IsActive] BIT CONSTRAINT [DF_Documents_IsActive] DEFAULT ((0)) NOT NULL, 
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Documents_DocumentTypes] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes] ([Id])
)
