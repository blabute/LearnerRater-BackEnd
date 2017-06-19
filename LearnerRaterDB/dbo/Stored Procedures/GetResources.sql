CREATE PROCEDURE [dbo].[GetResources]
	@Category varchar(30)
AS
	SELECT  [Resource_ID],
			[Category],
			[Title],
			[Author],
			[Description],
			[Website],
			[URL]
	FROM CourseResources
	WHERE [Category] = @Category

