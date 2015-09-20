
CREATE PROCEDURE dbo.GetThumbnail
@id int,
@albumID int
AS
BEGIN
	select Thumbnail from Photos where PhotoID=@id and AlbumID=@albumID
END
