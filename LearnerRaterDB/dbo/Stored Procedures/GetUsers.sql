CREATE PROCEDURE [dbo].[GetUsers]
	@Username varchar(50),
	@ResponseMessage NVARCHAR(250) OUTPUT
AS
BEGIN

	IF EXISTS (SELECT TOP 1 User_ID FROM [dbo].[Users] WHERE Username=@Username)
    BEGIN
		SELECT [Password], [FullName], [Email], [User_Id], [Username], [IsAdmin]
		FROM Users
			WHERE Username=@Username
    END
    ELSE
       SET @ResponseMessage='Invalid login'
END
