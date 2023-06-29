CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    CONSTRAINT [CK_Contact_Email] CHECK (email like '__%@__%.%'), 
    PRIMARY KEY ([Id])
)
