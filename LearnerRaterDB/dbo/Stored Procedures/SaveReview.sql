CREATE PROCEDURE [dbo].[SaveReview]
	@Resource_ID bigint,
	@Review_ID bigint out,
	@Username varchar(50),
	@Rating int,
	@Comments varchar(MAX)
AS
	IF ((SELECT COUNT(1) FROM CourseReviews WHERE [Resource_ID] = @Resource_ID AND [Review_ID] = @Review_ID) =0)
	BEGIN
		INSERT INTO CourseReviews([Resource_ID], [Username], [Rating], [Comments])
		VALUES (@Resource_ID, @Username, @Rating, @Comments)
		SET @Review_ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE CourseReviews
		SET [Username] = @Username,
			[Rating] = @Rating,
			[Comments] = @Comments
		WHERE [Resource_ID] = @Resource_ID
		AND [Review_ID] = @Review_ID

	END
