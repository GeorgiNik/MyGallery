USE [master]
GO
/****** Object:  Database [UserDB]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
CREATE DATABASE [UserDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserDB', FILENAME = N'C:\Users\georgi.nikolov\UserDB.mdf' , SIZE = 176192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UserDB_log', FILENAME = N'C:\Users\georgi.nikolov\UserDB_log.ldf' , SIZE = 39936KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UserDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UserDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UserDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UserDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UserDB] SET  MULTI_USER 
GO
ALTER DATABASE [UserDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UserDB]
GO
/****** Object:  StoredProcedure [dbo].[Album]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Album]
@username varchar(150),
@albumID int
AS
BEGIN
	SELECT *  FROM  Photos  where AlbumID=@albumID and UserName=@username  ORDER BY DateCreated DESC;
END

GO
/****** Object:  StoredProcedure [dbo].[CreateAlbum]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateAlbum]
	@AlbumName varchar(150),
	@Description varchar(500),
	@DateCreated datetime,
	@public bit,
	@UserName varchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  insert into Albums(AlbumName,Description,DateCreated,IsPublished,UserName) 
  values (@AlbumName,@Description,@DateCreated,@public,@UserName)
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAlbum]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAlbum]
@id int
AS
BEGIN
	delete from Albums where AlbumID=@id delete from Photos where AlbumID=@id
END

GO
/****** Object:  StoredProcedure [dbo].[DeletePhoto]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletePhoto]
@id int
AS
BEGIN
	delete
	from Photos 
	where PhotoID=@id
END

GO
/****** Object:  StoredProcedure [dbo].[Gallery]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Gallery]
@username varchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM  Albums where UserName=@username ORDER BY DateCreated DESC;
END

GO
/****** Object:  StoredProcedure [dbo].[GetPhotosWithoutThumb]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPhotosWithoutThumb]

AS
BEGIN
	
	SET NOCOUNT ON;
	select PhotoID,Photo from Photos where Thumbnail IS NULL 
END

GO
/****** Object:  StoredProcedure [dbo].[GetThumbnail]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetThumbnail]
@id int,
@albumID int
AS
BEGIN
	select Thumbnail from Photos where PhotoID=@id and AlbumID=@albumID
END

GO
/****** Object:  StoredProcedure [dbo].[Insert_User]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_User]
      @Username NVARCHAR(20),
      @Password NVARCHAR(20),
      @Email NVARCHAR(30)
AS
BEGIN
      SET NOCOUNT ON;
      IF EXISTS(SELECT UserId FROM Users WHERE Username = @Username)
      BEGIN
            SELECT -1 -- Username exists.
      END
      ELSE IF EXISTS(SELECT UserId FROM Users WHERE Email = @Email)
      BEGIN
            SELECT -2 -- Email exists.
      END
      ELSE
      BEGIN
            INSERT INTO [Users]
                     ([Username]
                     ,[Password]
                     ,[Email]
                     ,[CreatedDate])
            VALUES
                     (@Username
                     ,@Password
                     ,@Email
                     ,GETDATE())
           
            SELECT SCOPE_IDENTITY() -- UserId                 
     END
END
Exec Insert_User

GO
/****** Object:  StoredProcedure [dbo].[InserThumbanil]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InserThumbanil]
	@Thumbnail varbinary(MAX),
	@PhotoID int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE Photos
    SET Thumbnail=@Thumbnail
	where PhotoID=@PhotoID
END

GO
/****** Object:  StoredProcedure [dbo].[PublicAlbum]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PublicAlbum]
@albumID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM  Photos where AlbumID=@albumID
END

GO
/****** Object:  StoredProcedure [dbo].[PublicOnly]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PublicOnly]
@published bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT AlbumID,AlbumName,Description,IsPublished,UserName FROM  Albums where  IsPublished=@published order by DateCreated desc
END

GO
/****** Object:  StoredProcedure [dbo].[PublishAlbum]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PublishAlbum]
@id int,
@publish bit
AS
BEGIN
	UPDATE Albums SET IsPublished=@publish where AlbumID=@id
END

GO
/****** Object:  StoredProcedure [dbo].[SelectPhoto]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectPhoto] 
	@id int 
AS
BEGIN
	
	SET NOCOUNT ON;

    
	select Photo from Photos where PhotoID=@id
	print @id
END
exec SelectPhoto 39
GO
/****** Object:  StoredProcedure [dbo].[UnPublishAlbum]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UnPublishAlbum]
@id int,
@publish bit
AS
BEGIN
	UPDATE Albums SET IsPublished=@publish where AlbumID=@id
END

GO
/****** Object:  StoredProcedure [dbo].[UplodImage]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UplodImage]
@Name varchar (150),
@ContentType varchar(100),
@Description varchar(500),
@Photo varbinary(MAX),
@DateCreated datetime,
@AlbumID int,
@username varchar(150)	
AS
BEGIN
	insert into Photos(Name, ContentType,Description, Photo,DateCreated,AlbumID,UserName)
    values (@Name, @ContentType,@Description, @Photo,@DateCreated,@AlbumID,@username)
	SELECT SCOPE_IDENTITY()  
END

GO
/****** Object:  StoredProcedure [dbo].[Validate_User]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Validate_User]
      @Username NVARCHAR(20),
      @Password NVARCHAR(20)
AS
BEGIN
      SET NOCOUNT ON;
      DECLARE @UserId INT, @LastLoginDate DATETIME
     
      SELECT @UserId = UserId, @LastLoginDate = LastLoginDate
      FROM Users WHERE Username = @Username AND [Password] = @Password
     
      IF @UserId IS NOT NULL
      BEGIN
            IF NOT EXISTS(SELECT UserId FROM UserActivation WHERE UserId = @UserId)
            BEGIN
                  UPDATE Users
                  SET LastLoginDate = GETDATE()
                  WHERE UserId = @UserId
                  SELECT @UserId [UserId] -- User Valid
            END
            ELSE
            BEGIN
                  SELECT -2 -- User not activated.
            END
      END
      ELSE
      BEGIN
            SELECT -1 -- User invalid.
      END
END

GO
/****** Object:  Table [dbo].[Albums]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](150) NULL,
	[Description] [varchar](500) NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsPublished] [bit] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Photos](
	[PhotoID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumID] [int] NULL,
	[Name] [varchar](50) NULL,
	[ContentType] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Photo] [varbinary](max) NULL,
	[DateCreated] [datetime] NULL,
	[Thumbnail] [varbinary](max) NULL,
	[UserName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[PhotoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserActivation]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivation](
	[UserId] [int] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserActivation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Albums]    Script Date: 27.7.2015 г. 15:22:32 ч. ******/
CREATE NONCLUSTERED INDEX [IX_Albums] ON [dbo].[Albums]
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [UserDB] SET  READ_WRITE 
GO
