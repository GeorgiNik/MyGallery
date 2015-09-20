
CREATE PROCEDURE [dbo].[GetPhotosWithoutThumb]

AS
BEGIN
	
	SET NOCOUNT ON;
	select PhotoID,Photo from Photos where Thumbnail IS NULL 
END
