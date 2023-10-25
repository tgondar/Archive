﻿<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntDelegate" Codebehind="mntDelegate.aspx.cs" %>

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
        <asp:Label ID="Label1" runat="server" Text="Noma" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
            ID="txtName" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                ID="Label2" runat="server" Text="Morada" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                    ID="txtAddress" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                        ID="Label3" runat="server" Text="Tlf" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                            ID="txtPhone" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label 
            ID="Label6" runat="server" CssClass="textLabel" Text="Tlm"></asp:Label>
&nbsp;<asp:TextBox ID="txtMPhone" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label
                                ID="Label4" runat="server" Text="Fax" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                    ID="txtFax" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                                        ID="Label5" runat="server" Text="Email" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                            ID="txtEmail" runat="server" CssClass="textTextBox"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtEmail" CssClass="textError" ErrorMessage="*" ForeColor="" 
            SetFocusOnError="True" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="InsertSave"></asp:RegularExpressionValidator>
        &nbsp;<asp:LinkButton ID="lkbSearch" runat="server" CssClass="textLink" 
            onclick="lkbSearch_Click">Pesquisar</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="lkbInsert" runat="server" CssClass="textLink" 
            ValidationGroup="InsertSave" onclick="lkbInsert_Click">Inserir</asp:LinkButton>
        <asp:LinkButton ID="lkbSave" runat="server" CssClass="textLink" Visible="False" 
            ValidationGroup="InsertSave" onclick="lkbSave_Click">Gravar</asp:LinkButton>
    </div>

    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados</div>
    </div>
    <div class="divContentFields">
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CellSpacing="1" CssClass="textLabel" ForeColor="#333333" 
            GridLines="None" onselectedindexchanged="gvExecuted_SelectedIndexChanged">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                <asp:BoundField DataField="name" HeaderText="Nome" HtmlEncode="False" />
                <asp:BoundField DataField="Address" HeaderText="Morada" HtmlEncode="False" />
                <asp:BoundField DataField="phone" HeaderText="Tlf" HtmlEncode="False" />
                <asp:BoundField DataField="MPhone" HeaderText="Tlm" />
                <asp:BoundField DataField="fax" HeaderText="Fax" HtmlEncode="False" />
                <asp:BoundField DataField="email" HeaderText="Email" HtmlEncode="False" />
                <asp:BoundField DataField="UserName" HeaderText="Utilizador" />
                <asp:BoundField DataField="alterdate" HeaderText="Data" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <asp:LinkButton ID="lkbPrev" runat="server" CssClass="textLink" 
            onclick="lkbPrev_Click">&lt; Anterior</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lkbNext" runat="server" CssClass="textLink" 
            onclick="lkbNext_Click">Próximo &gt;</asp:LinkButton>
            </div>
        <br />
        <br />
</asp:Content>

