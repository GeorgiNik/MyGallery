
CREATE PROCEDURE [dbo].[Album]
@username varchar(150),
@albumID int
AS
BEGIN
	SELECT *  FROM  Photos  where AlbumID=@albumID and UserName=@username  ORDER BY DateCreated DESC;
END
