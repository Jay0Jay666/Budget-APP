CREATE TABLE [dbo].[Profile] (
    [UserId]   INT           NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Surname]  NVARCHAR (50) NOT NULL,
	[Username] NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

