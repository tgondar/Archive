<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntUserSettings" Codebehind="mntUserSettings.aspx.cs" %>

<%@ Register src="wucUserSettings.ascx" tagname="wucUserSettings" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:left;">
        <uc1:wucUserSettings ID="wucUserSettings1" runat="server" />
    </div>
</asp:Content>

