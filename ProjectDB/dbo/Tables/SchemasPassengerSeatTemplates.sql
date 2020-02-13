CREATE TABLE [dbo].[SchemasPassengerSeatTemplates] (
    [PassengerSeatTemplatId] UNIQUEIDENTIFIER NOT NULL,
    [SchemaId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_SchemasPassengerSeatTemplates_PassengerSeatTemplates] FOREIGN KEY ([PassengerSeatTemplatId]) REFERENCES [dbo].[PassengerSeatTemplates] ([Id]),
    CONSTRAINT [FK_SchemasPassengerSeatTemplates_Schemas] FOREIGN KEY ([SchemaId]) REFERENCES [AirplaneSchemas] ([Id])
);

