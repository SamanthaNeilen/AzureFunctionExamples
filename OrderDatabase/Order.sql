CREATE TABLE [dbo].[Order]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [PersonID] INT NOT NULL, 
    [OrderNumber] NVARCHAR(10) NOT NULL, 
    [Status] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Order_Person] FOREIGN KEY ([PersonID]) REFERENCES Person([Id])
)
