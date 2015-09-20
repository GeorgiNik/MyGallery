
CREATE PROCEDURE [dbo].[PublicOnly]
@published bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM  Albums where  IsPublished=@published order by DateCreated desc
END
