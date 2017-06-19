CREATE PROCEDURE [dbo].[DeleteResource]
	@Resource_ID bigint
AS
	DELETE FROM CourseResources
	WHERE [Resource_ID] = @Resource_ID
