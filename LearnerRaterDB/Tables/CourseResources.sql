CREATE TABLE [dbo].[CourseResources]
(
	[Resource_ID] BIGINT IDENTITY (1, 1) NOT NULL, 
	[Category] VARCHAR(30) NULL,
    [Title] VARCHAR(100) NULL, 
    [Author] VARCHAR(50) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Website] VARCHAR(50) NULL, 
    [URL] VARCHAR(200) NULL ,
	PRIMARY KEY CLUSTERED ([Resource_ID] ASC)
)
