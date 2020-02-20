CREATE TABLE [dbo].[Airplanes]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Airplanes_Id] DEFAULT (newid()) NOT NULL,
    [AirplaneSubTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [AirplaneTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [AirplaneSchemaId] UNIQUEIDENTIFIER NOT NULL, 
    [AirlineId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL,
    [CarryingCapacity] DECIMAL NOT NULL , 
    CONSTRAINT [PK_Airplanes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Schemas_AirplaneSubTypes] FOREIGN KEY ([AirplaneSubTypeId]) REFERENCES AirplaneSubTypes([Id]), 
    CONSTRAINT [FK_Schemas_AirplaneTypes] FOREIGN KEY ([AirplaneTypeId]) REFERENCES AirplaneTypes([Id]), 
    CONSTRAINT [FK_Schemas_Airlines] FOREIGN KEY ([AirlineId]) REFERENCES Airlines([Id]),
    CONSTRAINT [FK_Schemas_AirplaneSchemas] FOREIGN KEY ([AirplaneSchemaId]) REFERENCES AirplaneSchemas([Id])
)
