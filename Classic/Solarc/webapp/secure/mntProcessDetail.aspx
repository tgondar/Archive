<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntProcessDetail" Codebehind="mntProcessDetail.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:left;">
    <asp:DropDownList ID="cmbTable" runat="server" CssClass="textLabelB">
        <asp:ListItem Text="Seleccione Tabela" Value="0"></asp:ListItem>
        <asp:ListItem Text="Acordo Pagamento" Value="PaymentAgreement"></asp:ListItem>
        <asp:ListItem Text="Certidão de Incobrabilidade" Value="UncollectabilityCertificate"></asp:ListItem>
        <asp:ListItem Text="Código Extinção" Value="ExtinctionCode"></asp:ListItem>
        <asp:ListItem Text="Consulta Base de Dados" Value="DBInfo"></asp:ListItem>
        <asp:ListItem Text="Diligências no Local" Value="ArrangementsInPlace"></asp:ListItem>
        <asp:ListItem Text="Estado Processo" Value="ProcessState"></asp:ListItem>
        <asp:ListItem Text="Extinção Processo" Value="ProcessExtinction"></asp:ListItem>
        <asp:ListItem Text="Localização" Value="Localization"></asp:ListItem>
    </asp:DropDownList> 
    &nbsp;<asp:LinkButton ID="lkbOk" runat="server" CssClass="textLink" 
    onclick="lkbOk_Click">Ok</asp:LinkButton>
<br />
<asp:Panel ID="pnEdit" runat="server" Visible="False">
    <asp:Label ID="Label1" runat="server" Text="Designação" CssClass="textLabel"></asp:Label>
    &nbsp;<asp:TextBox ID="txtName" runat="server" CssClass="textTextBox" 
        MaxLength="100"></asp:TextBox>
    &nbsp;<asp:LinkButton ID="lkbAdd" runat="server" CssClass="textLink" 
        onclick="lkbAdd_Click">Inserir</asp:LinkButton>
    <asp:LinkButton ID="lkbSave" runat="server" CssClass="textLink" 
        onclick="lkbSave_Click" Visible="False">Gravar</asp:LinkButton>
</asp:Panel>
<asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" CellSpacing="1" CssClass="textLabel" ForeColor="#333333" 
    GridLines="None" onselectedindexchanged="gvResult_SelectedIndexChanged">
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:CommandField ButtonType="Image" 
            SelectImageUrl="~/images/webapp/icons/edit.png" ShowSelectButton="True" />
        <asp:BoundField DataField="Name" HeaderText="Designação" HtmlEncode="false" />
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
</asp:Content>

