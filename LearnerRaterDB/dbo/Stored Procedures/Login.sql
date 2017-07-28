CREATE PROCEDURE [dbo].[Login]
	@Username varchar(50),
	@Password varchar(50),
	@LoggedOnSuccessfully BIT OUTPUT,
	@ResponseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	
	DECLARE @User_ID INT
	SET @LoggedOnSuccessfully = 0

	IF EXISTS (SELECT TOP 1 User_ID FROM [dbo].[Users] WHERE Username=@Username)
    BEGIN
       SET @User_ID=(SELECT User_ID FROM [dbo].[Users] WHERE Username=@Username AND Password=HASHBYTES('SHA2_512', @Password+CAST(PasswordSalt AS NVARCHAR(36))))

       IF(@User_ID IS NULL)
           SET @ResponseMessage='Incorrect password'
       ELSE
	   BEGIN
		   SET @LoggedOnSuccessfully = 1 
           SET @ResponseMessage='User successfully logged in'
		END
    END
    ELSE
       SET @ResponseMessage='Invalid login'
END
