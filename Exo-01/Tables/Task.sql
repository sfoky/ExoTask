CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[IdCategory] INT NOT NULL,
	[IdPerson]  INT NOT NULL,
	[Descr] VARCHAR(500) NOT NULL,
	[CreationDate] DATETIME2 NOT NULL,
	[EndingDateMax] DATETIME2 NOT NULL,
	[EndingDate] DATETIME2, 
    CONSTRAINT [FK_Task_Category] FOREIGN KEY (IdCategory) REFERENCES [Category]([Id]),
	CONSTRAINT [FK_Task_Person] FOREIGN KEY (IdPerson) REFERENCES [Person]([Id]),
	CONSTRAINT [CK_Task_EndingDate_CreationDate] CHECK (EndingDate > CreationDate),
	CONSTRAINT [CK_Task_EndingDateMax_CreationDate] CHECK (EndingDateMax > CreationDate),
)
