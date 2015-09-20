
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
