CREATE TABLE [dbo].[Users] (
    [UserId]        INT           IDENTITY (1, 1) NOT NULL,
    [Username]      NVARCHAR (20) NOT NULL,
    [Password]      NVARCHAR (20) NOT NULL,
    [Email]         NVARCHAR (30) NOT NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [LastLoginDate] DATETIME      NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

