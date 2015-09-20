<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicAlbum.aspx.cs" Inherits="TestProject.PublicAlbum" MasterPageFile="~/MasterPage.Master" EnableEventValidation="false" %>

<asp:Content runat="server" ID="AlbumHead" ContentPlaceHolderID="head">
    <style type="text/css">
        .item {
            clear: both;
            display: inline-block;
            margin-right: 10px;
            margin-bottom: 10px;
        }

        .group {
            float: left;
            margin: 3px;
            padding: 2px;
            display: inline-block;
        }


        .button {
            margin-right: 10px;
            margin-bottom: 20px;
            Height: 32px;
            Width: 175px;
        }

        .imageBtn {
            width: 40px;
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <%--<asp:Button ID="UploadBtn" runat="server" Text="Upload Photos " CssClass="button" OnCommand="UploadBtn_Command" CommandArgument='<%# Request.QueryString["AlbumID"] %>' CommandName="upload" />--%>

    <asp:Button ID="FbShareBtn" runat="server" Text="Share" OnClick="FbShareBtn_Click" CssClass="button" />
    <br />
    <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">


        <ItemTemplate>
            <div id="Div1" runat="server" class="item">
                <table style='border: 2px solid black;'>
                    <tr>
                        <asp:Label ID="Label3" runat="server" Text='Photo Name : ' Font-Bold="true"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%#: Eval("Name") %>'></asp:Label>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoID", "~/Thumbnail.ashx?PhotoID={0}") + "&AlbumID=" +Request.QueryString["AlbumID"]%>' />
                        </td>
                        <td>

                            <asp:Label ID="Label2" runat="server" Text='Description:'></asp:Label>

                            <br />
                            
                            <textarea id="TextArea1" cols="20" rows="2" readonly="readonly"><%#: Eval("Description")  %></textarea>

                            <br />

                            <asp:ImageButton ID="downloadBtn" runat="server" ImageUrl="~/Icons/downloads.png" CssClass="imageBtn"  ToolTip="Download this image" OnCommand="downloadBtn_Command" CommandArgument='<%#: Eval("PhotoID")%>' CommandName="download" />

                        </td>
                    </tr>

                </table>
            </div>
        </ItemTemplate>

    </asp:ListView>
    

</asp:Content>
