
CREATE PROCEDURE dbo.PublishAlbum
@id int,
@publish bit
AS
BEGIN
	UPDATE Albums SET IsPublished=@publish where AlbumID=@id
END
