CREATE TABLE [dbo].[Profile] (
    [UserID]   INT           NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Surname]  NVARCHAR (50) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [GenderID] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([UserID] ASC), 
    CONSTRAINT [FK_Profile_Gender] FOREIGN KEY ([GenderID]) REFERENCES [Gender]([GenderID])
);


