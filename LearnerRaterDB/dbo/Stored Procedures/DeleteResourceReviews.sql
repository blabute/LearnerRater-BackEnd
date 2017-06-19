CREATE PROCEDURE [dbo].[DeleteResourceReviews]
	@Resource_ID bigint
AS
	DELETE FROM CourseReviews
	WHERE [Resource_ID] = @Resource_ID
