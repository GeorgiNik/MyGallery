
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
