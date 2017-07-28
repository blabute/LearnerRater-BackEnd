CREATE TABLE [dbo].[Users]
(
	[User_ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NULL, 
    [Password] BINARY(64) NULL, 
    [PasswordSalt] UNIQUEIDENTIFIER NULL
)
