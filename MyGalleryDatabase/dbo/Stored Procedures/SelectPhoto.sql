
CREATE PROCEDURE [dbo].[SelectPhoto] 
	@id int 
AS
BEGIN
	
	SET NOCOUNT ON;

    
	select Photo from Photos where PhotoID=@id
	print @id
END
exec SelectPhoto 39