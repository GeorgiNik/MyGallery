-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.CreateAlbum
	@AlbumName varchar(150),
	@Description varchar(500),
	@DateCreated datetime,
	@public bit,
	@UserName varchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  insert into Albums(AlbumName,Description,DateCreated,IsPublished,UserName) 
  values (@AlbumName,@Description,@DateCreated,@public,@UserName)
END
