<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.admin_Message" Codebehind="admin_Message.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:left; padding:5px;">
        <div class="divErro">
            <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
        </div>
    <asp:TextBox ID="txtValue" runat="server" CssClass="textTextBox" MaxLength="500" 
            Width="600px"></asp:TextBox>
&nbsp;<asp:LinkButton ID="lkbSave" runat="server" Enabled="false" 
        onclick="lkbSave_Click" CssClass="textLink">Gravar</asp:LinkButton>
    <br />
    <br />
    <asp:GridView ID="gvResult" runat="server" CssClass="textLabel" 
        onselectedindexchanged="gvResult_SelectedIndexChanged" 
            AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" ForeColor="#333333" 
            GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:CommandField SelectText="Editar" ShowSelectButton="True" >
            <ItemStyle CssClass="textLink" />
            </asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="value" HeaderText="Valor" HtmlEncode="False" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblMessages" runat="server" CssClass="textLabel"></asp:Label>
</div>
</asp:Content>

