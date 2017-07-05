CREATE PROCEDURE [dbo].[SaveResource]
	@Resource_ID bigint out,
	@Category varchar(30),
	@Title varchar(100),
	@Author varchar(50),
	@Description varchar(MAX),
	@Website varchar(50),
	@URL varchar(2048)
AS
	IF ((SELECT COUNT(1) FROM CourseResources WHERE [Resource_ID] = @Resource_ID) =0)
	BEGIN
		INSERT INTO CourseResources([Category], [Title], [Author], [Description], [Website], [URL])
		VALUES (@Category, @Title, @Author, @Description, @Website, @URL)
		SET @Resource_ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE CourseResources
		SET [Category] = @Category,
			[Title] = @Title,
			[Author] = @Author,
			[Description] = @Description,
			[Website] = @Website,
			[URL] = @URL
		WHERE [Resource_ID] = @Resource_ID
	END

