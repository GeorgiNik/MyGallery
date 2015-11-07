<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestProject.Accounts.Login" MasterPageFile="~/MasterPage.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Login</title>
    <link href="Styles/Styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
    <asp:Panel DefaultButton="LogInButton" runat="server">
            <h1>Login:</h1>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelUser" runat="server" Text="Username:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="UserField" runat="server" Width="260px"></asp:TextBox>
                    </td>
                    <td>

                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelPass" runat="server" Text="Password:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="PassField" runat="server" Width="260px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="LogInButton" runat="server" Text="Log In" Width="112px" OnClick="LogInButton_Click"  />
                        <asp:Button ID="RegisterRedirect" runat="server" Text="Sign Up" Width="94px" OnClick="RegisterRedirect_Click" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RememberCheckBox" runat="server"  Text="Remember me" OnCheckedChanged="RememberCheckBox_CheckedChanged"/>
                    </td>
                </tr>
            </table>

        </asp:Panel>

        
</asp:Content>
