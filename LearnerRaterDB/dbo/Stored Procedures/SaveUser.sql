CREATE PROCEDURE [dbo].[SaveUser]
	@User_ID bigint out,
	@Username varchar(50),
	@Password varchar(128),
	@Email varchar(50),
	@FullName varchar(50),
	@ResponseMessage NVARCHAR(250) OUTPUT
AS
BEGIN

	BEGIN TRY
		
		IF EXISTS (SELECT TOP 1 User_ID FROM [dbo].[Users] WHERE Username=@UserName)
		BEGIN
			SET @ResponseMessage='User already exists'
		END
		ELSE
		BEGIN
		
			INSERT INTO Users([Username], [Password], [Email], [FullName])
			VALUES (@Username, @Password, @Email, @FullName)
			SET @User_ID = @@IDENTITY

			SET @ResponseMessage='Success'

		END

	END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH
END
