﻿CREATE TABLE [dbo].[Person]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,  
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Email] NVARCHAR(255) NOT NULL
)
