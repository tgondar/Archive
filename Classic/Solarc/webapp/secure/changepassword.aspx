<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.changepassword" Codebehind="changepassword.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
        <asp:ChangePassword ID="ChangePassword1" runat="server" 
        ContinueDestinationPageUrl="~/webapp/secure/Default.aspx" BackColor="#F7F6F3" 
            BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
            CancelButtonText="Cancelar" ChangePasswordButtonText="Alterar Password" 
            ChangePasswordTitleText="Altere a sua Password" 
            ConfirmNewPasswordLabelText="Confirme Nova Password:" Font-Names="Verdana" 
            Font-Size="0.8em" NewPasswordLabelText="Nova Password:">
            <CancelButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="X-Small" 
                ForeColor="#284775" />
            <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                ForeColor="#284775" />
            <ChangePasswordButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="X-Small" 
                ForeColor="#284775" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                ForeColor="White" />
            <TextBoxStyle CssClass="textTextBox" Font-Size="0.8em" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        </asp:ChangePassword>
    </div>
</asp:Content>

