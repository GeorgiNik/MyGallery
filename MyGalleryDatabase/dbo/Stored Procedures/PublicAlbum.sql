﻿
CREATE PROCEDURE dbo.PublicAlbum
@albumID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM  Photos where AlbumID=@albumID
END
