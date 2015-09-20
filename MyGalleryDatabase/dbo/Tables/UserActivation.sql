CREATE TABLE [dbo].[UserActivation] (
    [UserId]         INT              NOT NULL,
    [ActivationCode] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UserActivation] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

