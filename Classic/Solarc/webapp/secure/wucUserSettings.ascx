<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucUserSettings"
    CodeBehind="wucUserSettings.ascx.cs" %>
<div style="padding:10px;">
    <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    <asp:Label ID="Label1" runat="server" Text="Cor da aplicação" 
        CssClass="textLabel"></asp:Label>
    <br />
    <asp:DropDownList ID="cmbTheme" CssClass="textDropDown" runat="server">
    </asp:DropDownList>
    <p>
        <asp:Label ID="Label2" runat="server" CssClass="textLabel"
            Text="Quando pesquisar processos, se so existir 1 resultado deseja ser redireccionado para a pagina do processo ?"></asp:Label>
        <br />
        <asp:DropDownList ID="cmbSearchResult" CssClass="textDropDown" runat="server">
            <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
            <asp:ListItem Text="Não" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" CssClass="textLabel" Text="Grupo"></asp:Label><br />
        <asp:DropDownList CssClass="textDropDown" ID="cmbLocalization" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:ImageButton ID="imgBtSave" runat="server" 
            ImageUrl="~/images/webapp/icons/save.png" ToolTip="Gravar definições" 
            onclick="imgBtSave_Click" />
    </p>
</div>

