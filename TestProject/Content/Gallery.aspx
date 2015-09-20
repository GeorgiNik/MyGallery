<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="TestProject.Content.Gallery" MasterPageFile="~/MasterPage.Master" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="head">
    <style>
        .imageBtn {
            width: 40px;
            height: 40px;
            margin-right: 10px;
        }
    </style>
    <script type="text/javascript">
        function PopUp() {
            alert("Album published successfuly");

        }
        function PopUpUnpublish() {
            alert("Album has been unpublished");
        }
    </script>
</asp:Content>

<asp:Content ID="thiscont" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:ScriptManager ID="ScriptManger" runat="server" />

    <asp:Button ID="AddAlbumBtn" runat="server" Text="Add new album" OnClick="AddAlbumBtn_Click" />
    <br />
    <asp:UpdatePanel ID="UpdatePanelAlbums" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" >
                
                <ItemTemplate>

                    <div id="Div1" runat="server" style="display: inline-block;">
                        <table style='border: 2px solid black;'>
                            <tr>
                                <asp:Label ID="Label3" runat="server" Text='Album Name : ' Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text='<%#: Eval("AlbumName") %>'></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="AlbumImage" runat="server" ImageUrl="~/Icons/service-icon-album.png" Width="200" Height="200" OnCommand="AlbumImage_Command" CommandArgument='<%#: Eval("AlbumID")%>' CommandName="viewAlbum" />
                                </td>

                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='Description:'></asp:Label>

                                    <br />

                                    <textarea id="TextArea1" cols="20" rows="4" readonly="readonly"><%#: Eval("Description")  %></textarea>
                                    <br />
                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Icons/delete.png" CssClass="imageBtn"  ToolTip="Delete this Album"  OnCommand="btnDelete_Command" CommandArgument='<%#: Eval("AlbumID")%>' CommandName="deleteAlbum" />
                                    <asp:ImageButton ID="btnShare" runat="server" ImageUrl="~/Icons/1435930758_145_Action.png" CssClass="imageBtn" ToolTip="Make this album public" OnClientClick="return confirm('Are you sure you want to publish this Album?') " OnCommand="btnShare_Command" CommandArgument='<%#: Eval("AlbumID")%>' CommandName="shareAlbum" />
                                    <asp:ImageButton ID="btnUnShare" runat="server"
                                        ImageUrl="~/Icons/1435935779_user_delete.png" CssClass="imageBtn" OnClientClick="return confirm('Are you sure you want to Unpublish this Album?') "
                                        OnCommand="btnUnShare_Command" CommandArgument='<%#: Eval("AlbumID")%>' CommandName="UnPublish" ToolTip="UnShare this album" />
                                </td>
                            </tr>

                        </table>
                    </div>

                </ItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
