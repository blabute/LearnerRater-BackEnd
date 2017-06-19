CREATE TABLE [dbo].[CourseReviews]
(
	[Review_ID] BIGINT IDENTITY (1, 1) NOT NULL,
	[Resource_ID] BIGINT NOT NULL, 
    [Username] VARCHAR(50) NULL, 
    [Rating] INT NULL, 
    [Comments] VARCHAR(MAX) NULL, 
	PRIMARY KEY CLUSTERED ([Review_ID], [Resource_ID] ASC),
    CONSTRAINT [FK_CourseReviews_CourseResources] FOREIGN KEY ([Resource_ID]) REFERENCES [CourseResources]([Resource_ID]) ON DELETE CASCADE
)
