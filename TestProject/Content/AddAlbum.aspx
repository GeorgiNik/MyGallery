<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAlbum.aspx.cs" Inherits="TestProject.Content.AddAlbum" MasterPageFile="~/MasterPage.Master" %>

<asp:Content runat="server" ID="AddAlbumHead" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 207px;
        }

        .auto-style3 {
            width: 207px;
            height: 87px;
        }

        .auto-style4 {
            height: 87px;
        }

        #TextArea1 {
            height: 68px;
            width: 264px;
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">



    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblAlbumName" runat="server" Text="Album name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAlbumName" runat="server" Width="265px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="DescriptionLbl" runat="server" Text="Description"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtDescr" runat="server" Height="71px" Style="margin-top: 0px" TextMode="MultiLine" Width="325px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
            <td>

                <asp:Button ID="CreateBtn" runat="server" Text="Create" OnClick="CreateBtn_Click" Width="91px" />

                <asp:Button ID="BackBtn" runat="server" Text="Back to Gallery" Width="99px" OnClick="BackBtn_Click" />
            </td>

        </tr>
    </table>


</asp:Content>
