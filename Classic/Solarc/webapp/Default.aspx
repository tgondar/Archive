<%@ Page Language="C#" AutoEventWireup="true" Inherits="webapp_Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["AppName"]); %></title>
    <style type="text/css">
        html,body {font-family:Verdana;font-size:10px; color:#ffffff; background-image:url(../images/website/back.gif);height:100%; width:100%; margin: 0px; padding: 0px;}
    </style>
    <link href="../includes/mainAppBlue.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="back">
            <div align="center" style="padding:100px 0 0 0;">
                <div style=" width:350px; background-color:#ffffff; padding:10px 0;">
                    <div style="margin:5px 0;">
                        <img src="../images/logo.png" alt="" />
                    </div>
                    <div style="width:300px; margin:0 0 10px 0; border:1px solid #000;">
<%--                        <div style="font-size:14px; margin:0 0 10px 0; color:#333333; font-weight:bold;">SolArc, Solicitors Archive</div>--%>
                        <div style="font-size:14px; margin:0 0 10px 0; color:#333333; font-weight:bold;">Insira as suas credenciais.</div>
                        <asp:Login ID="Login1" runat="server" TitleText="" 
                            DestinationPageUrl="~/webapp/secure/Default.aspx" PasswordLabelText="Password" 
                            UserNameLabelText="Utilizador" onloggingin="Login1_LoggingIn" 
                            onloggedin="Login1_LoggedIn" 
                            FailureText="Utilizador ou Password incorrecto(s), tente noavmente" 
                            LoginButtonText="Entrar" onauthenticate="Login1_Authenticate" 
                            RememberMeText="Manter sessão iniciada ?" DisplayRememberMe="False">
                            <TextBoxStyle CssClass="textLgTextBox" />
                            <LoginButtonStyle BorderStyle="None" CssClass="textLgBt" />
                            <LabelStyle CssClass="textLabel" />
                        </asp:Login>
                    </div>
                    <asp:Label ID="lblInfo" runat="server" CssClass="textError"></asp:Label>
                    <br />
                    <br />
                    <div style="color:#000;">
                        Rua Eugénio de Castro, n.º 352 - 2.º Sala 23 
                        <br />
                        4100-225 Porto 
                        <br />
                        <br />
                        Tlf. +351 225 101 757 <br />
                        Fax. +351 225 101 461
                    </div>
                </div>
            </div>
        </div>
        <%--<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />--%>
    </form>
</body>
</html>
