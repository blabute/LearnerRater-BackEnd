CREATE PROCEDURE [dbo].[Login]
	@Username varchar(50),
	@ResponseMessage NVARCHAR(250) OUTPUT
AS
BEGIN

	IF EXISTS (SELECT TOP 1 User_ID FROM [dbo].[Users] WHERE Username=@Username)
    BEGIN
		SELECT	[Password],
				[PasswordSalt]
		FROM Users
			WHERE Username=@Username
    END
    ELSE
       SET @ResponseMessage='Invalid login'
END
