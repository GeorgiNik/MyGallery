CREATE TABLE [dbo].[Albums] (
    [AlbumID]     INT            IDENTITY (1, 1) NOT NULL,
    [AlbumName]   VARCHAR (150)  NULL,
    [Description] VARCHAR (500)  NULL,
    [DateCreated] DATETIME       NOT NULL,
    [IsPublished] BIT            NOT NULL,
    [UserName]    NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED ([AlbumID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Albums]
    ON [dbo].[Albums]([AlbumID] ASC);

