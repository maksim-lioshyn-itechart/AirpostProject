CREATE TABLE [dbo].[SchemasPassengerSeatTemplates] (
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_SchemasPassengerSeatTemplates_Id] DEFAULT (newid()) NOT NULL,
    [PassengerSeatTemplateId] UNIQUEIDENTIFIER NOT NULL,
    [AirplaneSchemaId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_SchemasPassengerSeatTemplates_PassengerSeatTemplates] FOREIGN KEY ([PassengerSeatTemplateId]) REFERENCES [dbo].[PassengerSeatTemplates] ([Id]),
    CONSTRAINT [FK_SchemasPassengerSeatTemplates_Schemas] FOREIGN KEY ([AirplaneSchemaId]) REFERENCES [AirplaneSchemas] ([Id]), 
    CONSTRAINT [PK_SchemasPassengerSeatTemplates] PRIMARY KEY ([Id])
);

