CREATE TABLE [dbo].[Airplanes]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Airplanes_Id] DEFAULT (newid()) NOT NULL,
    [AirplaneConceptId] UNIQUEIDENTIFIER NOT NULL, 
    [AirlineId] UNIQUEIDENTIFIER NOT NULL, 
    [AirplaneSchemaId] UNIQUEIDENTIFIER NOT NULL, 
	[Name] NVARCHAR(50) NOT NULL, 
	[CarryingCapacity] DECIMAL NOT NULL , 
    CONSTRAINT [PK_Airplanes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Schemas_AirplaneContents] FOREIGN KEY ([AirplaneConceptId]) REFERENCES AirplaneConcepts([Id]), 
    CONSTRAINT [FK_Schemas_Airlines] FOREIGN KEY ([AirlineId]) REFERENCES Airlines([Id]),
    CONSTRAINT [FK_Schemas_AirplaneSchemas] FOREIGN KEY ([AirplaneSchemaId]) REFERENCES AirplaneSchemas([Id])
)
