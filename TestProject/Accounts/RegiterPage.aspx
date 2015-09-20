<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegiterPage.aspx.cs" Inherits="TestProject.RegiterPage" MasterPageFile="~/MasterPage.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Register</title>
    <link href="Styles/Styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--       <h1>Registration form:</h1>
            <table style="width: 100%;" >
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelUser" runat="server" Text="Username:"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="UserField" runat="server" Width="260px"></asp:TextBox>
                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="UserFieldValid" runat="server" ErrorMessage="Please entere username" Display="Dynamic" ControlToValidate="UserField" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="UsernameValidator" runat="server" Display="Dynamic"
                            ControlToValidate="UserField"
                            ErrorMessage="Username must contain only letters and numbers only"
                            ValidationExpression="[a-zA-Z0-9]*" ForeColor="Red" />
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
                        <asp:RequiredFieldValidator ID="PassFieldValid" runat="server" ErrorMessage="Please enter password" ControlToValidate="PassField" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LabelPassConf" runat="server" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="ConfPassField" runat="server" Width="260px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="ConfPassFieldValid" runat="server" ErrorMessage="Please confirm password"  Display="Dynamic" ControlToValidate="ConfPassField" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="PasswordMatchVaid" runat="server" Display="Dynamic" ControlToCompare="PassField" ControlToValidate="ConfPassField" ErrorMessage="Password does not match" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LabelEmail" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="EmailField" runat="server" Width="260px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="EmailFieldValid" runat="server" Display="Dynamic" ErrorMessage="Please enter email" ControlToValidate="EmailField" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailValidator" runat="server" Display="Dynamic" ControlToValidate="EmailField" ErrorMessage="Enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
               
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style5" rowspan="1">

                       <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="RegisterUser" />
                        
                    </td>

                    <td class="auto-style3"></td>
                </tr>
            </table>--%>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Accounts/Login.aspx" CreateUserButtonText="Registrate"   EmailRegularExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" EmailRegularExpressionErrorMessage="Enter valid email" CancelButtonType="Button" CancelDestinationPageUrl="~/Home.aspx" DisplayCancelButton="true" >
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" >
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
