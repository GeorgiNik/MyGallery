<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="TestProject.Content.UploadImage" MasterPageFile="~/MasterPage.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 277px;
        }
        .auto-style3 {
            width: 329px;
        }
        .auto-style5 {
            width: 277px;
            height: 88px;
        }
        .auto-style6 {
            width: 329px;
            height: 88px;
        }
        .auto-style7 {
            height: 88px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
            
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Select Image"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="315px"  AllowMultiple="true" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">

                        <asp:Label ID="lblImageDescription" runat="server" Text="Image Description"></asp:Label>

                    </td>
                    <td class="auto-style6">

                        <asp:TextBox ID="ImageDescriptionTxt" runat="server" Height="71px" style="margin-top: 0px" Width="325px"  TextMode="MultiLine" ></asp:TextBox>

                    </td>
                    <td class="auto-style7">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblMessage" runat="server" Text="Please select image file" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="UploadButton" runat="server" Text="Upload" Width="154px" OnClick="UploadButton_Click" />
                        <asp:Button ID="Redirect" runat="server" Text="Back to album" OnClick="Redirect_Click"  />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            
   </asp:Content>
