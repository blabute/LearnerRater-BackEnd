CREATE PROCEDURE [dbo].[SaveUser]
	@User_ID bigint out,
	@Username varchar(50),
	@Password varchar(50),
	@ResponseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	
	DECLARE @PasswordSalt UNIQUEIDENTIFIER=NEWID()

	BEGIN TRY
		
		IF EXISTS (SELECT TOP 1 User_ID FROM [dbo].[Users] WHERE Username=@UserName)
		BEGIN
			SET @ResponseMessage='User already exists'
		END
		ELSE
		BEGIN
		
			INSERT INTO Users([Username], [Password], [PasswordSalt])
			VALUES (@Username, HASHBYTES('SHA2_512', @Password+CAST(@PasswordSalt AS NVARCHAR(36))), @PasswordSalt)
			SET @User_ID = @@IDENTITY

			SET @ResponseMessage='Success'

		END

	END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH
END
