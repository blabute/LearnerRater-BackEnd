
CREATE PROCEDURE GetResourceCount 
	@Category varchar(30),
	@ResourceCount int out
AS

	SET @ResourceCount = (SELECT COUNT(1) 
						  FROM CourseResources 
					      WHERE Category = @Category)
