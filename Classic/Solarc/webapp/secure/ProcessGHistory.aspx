<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" CodeBehind="ProcessGHistory.aspx.cs" Inherits="Solarc.webapp.secure.ProcessGHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        Processo<asp:TextBox ID="txtProcess" runat="server"></asp:TextBox>
&nbsp;DataInicio<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
&nbsp;DataFim<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
        <asp:Button ID="btSearch" runat="server" Text="pesquisar" OnClick="btSearch_Click" />

<br />
<br />
<asp:Label ID="lblSearch" runat="server"></asp:Label>
<asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvResult_RowDeleting">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="ProcessCode" HeaderText="Processo"></asp:BoundField>
        <asp:BoundField DataField="Field" HeaderText="Campo"></asp:BoundField>
        <asp:BoundField DataField="FromValue" HeaderText="De"></asp:BoundField>
        <asp:BoundField DataField="ToValue" HeaderText="Para"></asp:BoundField>
        <asp:BoundField DataField="AlterUser" HeaderText="Utilizador"></asp:BoundField>
        <asp:BoundField DataField="AlterDate" HeaderText="Data"></asp:BoundField>
        <asp:CommandField DeleteText="Apagar" ShowDeleteButton="True" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <sortedascendingcellstyle backcolor="#F5F7FB" />
    <sortedascendingheaderstyle backcolor="#6D95E1" />
    <sorteddescendingcellstyle backcolor="#E9EBEF" />
    <sorteddescendingheaderstyle backcolor="#4870BE" />
</asp:GridView>

</asp:Content>
