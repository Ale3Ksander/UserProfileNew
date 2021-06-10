﻿CREATE TABLE [dbo].[Table]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(1024) NOT NULL, 
	[LastName] NVARCHAR(1024) NOT NULL, 
	[Age] SMALLINT NOT NULL,
	[PhoneNumber] NVARCHAR(1024) NOT NULL, 
	[Email] NVARCHAR(1024) NOT NULL, 
	[CreatedAt] DATETIME NOT NULL,
	[UpdatedAt] DATETIME NULL
)
