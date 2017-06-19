CREATE PROCEDURE [dbo].[GetReviews]
	@Resource_ID bigint
AS
	SELECT	[Review_ID],
			[Username],
			[Rating],
			[Comments]
	FROM CourseReviews
	WHERE [Resource_ID] = @Resource_ID

