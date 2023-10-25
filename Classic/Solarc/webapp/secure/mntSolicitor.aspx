<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntSolicitor" Codebehind="mntSolicitor.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    <div class="divContentTitle">
        <div class="divContent">
            1. Pesquisa</div>
    </div>
    <div class="divContentFields">
        <asp:Label ID="Label1" runat="server" Text="Nome" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
            ID="txtName" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                ID="Label2" runat="server" Text="Cédula" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                    ID="txtCardNumber" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:LinkButton ID="lkbSearch" runat="server" CssClass="textLink" OnClick="lkbSearch_Click">Pesquisar</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="lkbInsert" runat="server" CssClass="textLink" ValidationGroup="InsertSave"
            OnClick="lkbInsert_Click">Inserir</asp:LinkButton>
        <asp:LinkButton ID="lkbSave" runat="server" CssClass="textLink" Visible="False" ValidationGroup="InsertSave"
            OnClick="lkbSave_Click">Gravar</asp:LinkButton>
    </div>
    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados</div>
    </div>
    <div class="divContentFields">
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CellSpacing="1" EmptyDataText="Sem resultados." CssClass="textLabel" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvResult_SelectedIndexChanged">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Nome" HtmlEncode="False" />
                <asp:BoundField DataField="CardNumber" HeaderText="Cédula" HtmlEncode="False" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
