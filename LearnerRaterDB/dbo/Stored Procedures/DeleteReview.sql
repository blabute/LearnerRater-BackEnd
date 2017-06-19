CREATE PROCEDURE [dbo].[DeleteReview]
	@Resource_ID bigint,
	@Review_ID bigint
AS
	DELETE FROM CourseReviews
	WHERE [Resource_ID] = @Resource_ID
	AND [Review_ID] = @Review_ID