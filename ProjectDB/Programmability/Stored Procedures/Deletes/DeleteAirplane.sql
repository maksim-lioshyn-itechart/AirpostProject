CREATE PROCEDURE [dbo].[DeleteAirplane]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[Airplanes] WHERE Id = @Id
END
GO
