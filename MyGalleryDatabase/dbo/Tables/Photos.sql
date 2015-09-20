CREATE TABLE [dbo].[Photos] (
    [PhotoID]     INT             IDENTITY (1, 1) NOT NULL,
    [AlbumID]     INT             NULL,
    [Name]        VARCHAR (50)    NULL,
    [ContentType] VARCHAR (50)    NULL,
    [Description] VARCHAR (50)    NULL,
    [Photo]       VARBINARY (MAX) NULL,
    [DateCreated] DATETIME        NULL,
    [Thumbnail]   VARBINARY (MAX) NULL,
    [UserName]    NVARCHAR (100)  NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED ([PhotoID] ASC)
);

