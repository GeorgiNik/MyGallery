
CREATE PROCEDURE dbo.DeleteAlbum
@id int
AS
BEGIN
	delete from Albums where AlbumID=@id delete from Photos where AlbumID=@id
END
