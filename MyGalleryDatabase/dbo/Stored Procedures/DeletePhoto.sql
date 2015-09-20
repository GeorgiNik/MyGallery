
CREATE PROCEDURE dbo.DeletePhoto
@id int
AS
BEGIN
	delete
	from Photos 
	where PhotoID=@id
END
