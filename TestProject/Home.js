
function GetPublicAlbums() {
    $.ajax({
        type: "POST",
        url: "/WebUIService/MyGalleryWebService.asmx/GetPublicAlbums",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: OnSuccess,
        error: OnFail

    });
}

$(document).ready(GetPublicAlbums);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(GetPublicAlbums);

function Redirection(albumID) {

    window.location = "../PublicAlbum.aspx?AlbumID=" + albumID;

}
function OnSuccess(data) {

    var RsltElem = document.getElementById("mainContent");


    for (var i = 0, len = data.d.length; i < len; i++) {

        RsltElem.innerHTML += '<div  style="display: inline-block; margin-right:15px;"> <table style="border: 2px solid black;"><tr><h3 ID="Label3" >Album Name : </h3><span >'
            + data.d[i].AlbumName + '</span></tr><tr><td><a href="#" id="redirect" onclick="Redirection('
            + data.d[i].AlbumID + ');return false;"><img src="../Icons/service-icon-album.png" alt="redirect" class="thumbnail" /></td><td><h3 ID="Label2" >Description:</h3><br /><textarea id="TextArea1" cols="20" rows="5" readonly="readonly">'
            + data.d[i].Description + '</textarea><br /></td></tr></div>';
    }

}
function OnFail(error) {
    alert(error);
}
