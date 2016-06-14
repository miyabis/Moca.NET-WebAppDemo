CREATE PROCEDURE dbo.IDaoDemo_Get
	(
	@ID nvarchar(5),
	@Code int
	)
AS

SELECT
	[ID]
	,[Code]
	,[Name]
	,[Note]
FROM	[tbDemo]
WHERE	[ID] = @ID
	AND	[Code] = @Code


RETURN