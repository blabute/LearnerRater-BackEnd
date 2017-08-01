CREATE TABLE [dbo].[Users]
(
	[User_ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NULL, 
    [Password] VARCHAR(128) NULL, 
    [Email] VARCHAR(50) NULL, 
    [FullName] VARCHAR(50) NULL, 
    [IsAdmin] BIT NULL
)
