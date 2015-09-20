
CREATE PROCEDURE [dbo].[Gallery]
@username varchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM  Albums where UserName=@username ORDER BY DateCreated DESC;
END
