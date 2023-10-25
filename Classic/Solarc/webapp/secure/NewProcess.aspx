<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.NewProcess" Codebehind="NewProcess.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        Novo Processo Executivo<br />
        <br />
        <asp:Label ID="lblProcessNumber" runat="server" Text="Código Interno"></asp:Label>
        &nbsp;<asp:TextBox ID="txtInternalCode" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblCourtNumber" runat="server" Text="Número Tribunal"></asp:Label>
        &nbsp;<asp:TextBox ID="txtProcessNumber" runat="server"></asp:TextBox>
        <br />
        <asp:ImageButton ID="imgBtAdd" runat="server" 
            ImageUrl="~/images/webapp/icons/add.png" onclick="imgBtAdd_Click" 
            ToolTip="Criar" />
        <br />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>

</asp:Content>

