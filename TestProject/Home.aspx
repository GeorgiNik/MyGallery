<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TestProject.Home" MasterPageFile="~/MasterPage.Master" %>



<asp:Content runat="server" ContentPlaceHolderID="head">
    <style>
        h3#Label3 {
            display: inline;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager" runat="server">
        
        <Services>
            <asp:ServiceReference Path="WebUIService/MyGalleryWebService.asmx" />
        </Services>
        <Scripts>

            <asp:ScriptReference Path="~/Scripts/jquery-2.1.4.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-2.1.4.js" />
            <asp:ScriptReference Path="~/Home.js" />

        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanelPublicAlbums">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer" />
        </Triggers>
        <ContentTemplate>
            <div id="mainContent" ></div>
        </ContentTemplate>
        
    </asp:UpdatePanel>
    <asp:Timer ID="Timer" runat="server" Interval="10000"/>
    
    <%-- <h1>Published albums:</h1>
    <div id="Results"></div>
    <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
        <ItemTemplate>
            <div id="Div1" runat="server" style="display: inline-block;">
                <table style='border: 2px solid black;'>
                    <tr>
                        <asp:Label ID="Label3" runat="server" Text='Album Name : ' <img src="" alt="" />></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%#: Eval("AlbumName") %>'></asp:Label>
                    </tr>

                    <tr>
                        <td>
                            <asp:ImageButton ID="AlbumImage" runat="server" ImageUrl="~/Icons/service-icon-album.png" Width="200" Height="200" OnCommand="AlbumImage_Command" CommandArgument='<%#: Eval("AlbumID")%>' CommandName="viewAlbum" />
                        </td>

                        <td>
                            <asp:Label ID="Label2" runat="server" Text='Description:'></asp:Label>

                            <br />

                            <textarea id="TextArea1" cols="20" rows="5" readonly="readonly"><%#: Eval("Description")  %></textarea>

                            <br />

                        </td>

                    </tr>

                </table>
            </div>
           
        </ItemTemplate>

    </asp:ListView>--%>
</asp:Content>

