<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="TestProject.Content.Album" MasterPageFile="~/MasterPage.Master" %>

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
<asp:Content runat="server" ID="AlbumBody" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button ID="UploadBtn" runat="server" Text="Upload Photos " CssClass="button" OnCommand="UploadBtn_Command" CommandArgument='<%# Request.QueryString["AlbumID"] %>' CommandName="upload" />
    <asp:Button ID="ViewGalleryBtn" runat="server" Text="View Albums" CssClass="button" OnClick="ViewGalleryBtn_Click" />
    <asp:Button ID="FbShareBtn" runat="server" Text="Share" OnClick="FbShareBtn_Click" CssClass="button" />

    <br />

    <asp:UpdatePanel ID="UpdatePanelPhotos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
                <%-- <LayoutTemplate>
                <div runat="server" id="Products" >
                    
                    <div runat="server" id="groupPlaceholder" >
                    </div>
                </div>
            </LayoutTemplate>

            <GroupTemplate>
                <div runat="server" class="group">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"  />
                </div>
            </GroupTemplate>--%>

                <ItemTemplate>
                    <div runat="server" class="item">
                        <table style='border: 2px solid black;'>
                            <tr>
                                <asp:Label ID="Label3" runat="server" Text='Photo Name : ' Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text='<%#: Eval("Name") %>'></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoID", "~/Thumbnail.ashx?PhotoID={0}")+"&AlbumID=" +Request.QueryString["AlbumID"]%>' OnCommand="downloadBtn_Command" CommandArgument='<%#: Eval("PhotoID")%>' CommandName="download" />
                                    <%--<asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoID", "~/Thumbnail.ashx?PhotoID={0}")+"&AlbumID=" +Request.QueryString["AlbumID"]%>' />--%>
                                </td>
                                <%--<asp:Image ID="Image1" Width="200" Height="200" runat="server" ImageUrl='<%#: Eval("PhotoID", "MyGallery.aspx?PhotoID={0}")%>' /></td>--%>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='Description:'></asp:Label>
                                    <br />
                                    <textarea id="TextArea1" cols="20" rows="2" readonly="readonly"><%#: Eval("Description")  %></textarea>
                                    <br />
                                    <asp:ImageButton ID="deleteBtn" runat="server" ImageUrl="~/Icons/delete.png" ToolTip="Delete this image" CssClass="imageBtn" OnClientClick="return confirm('Are you sure you want to delete this Photo?')" OnCommand="deleteBtn_Command" CommandArgument='<%#: Eval("PhotoID")%>' CommandName="deletePhoto" />
                                    <asp:ImageButton ID="downloadBtn" runat="server" ImageUrl="~/Icons/downloads.png" ToolTip="Download" CssClass="imageBtn" OnCommand="downloadBtn_Command" CommandArgument='<%#: Eval("PhotoID")%>' CommandName="download" />

                                </td>
                            </tr>

                        </table>
                    </div>
                </ItemTemplate>

            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
