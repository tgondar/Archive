<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.Representative" Codebehind="Representative.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    <div class="divContentTitle">
        <div class="divContent">
            1. Opções de Pesquisa</div>
    </div>
    <div class="divContentFields">
        <asp:Label ID="Label1" CssClass="textLabel" runat="server" Text="Num Interno"></asp:Label>
    <asp:TextBox ID="txtInternalNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
    &nbsp;<asp:Label ID="Label6" CssClass="textLabel" runat="server" Text="Num Processo"></asp:Label>
    <asp:TextBox ID="txtProcessNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
    &nbsp;<asp:Label CssClass="textLabel" ID="Label3" runat="server" Text="Exequente"></asp:Label>
    <asp:TextBox ID="txtCreditor" runat="server" CssClass="textTextBox"></asp:TextBox>
&nbsp;<asp:Label ID="Label5" CssClass="textLabel" runat="server" Text="Executado"></asp:Label>
    <asp:TextBox ID="txtExecuted" runat="server" CssClass="textTextBox"></asp:TextBox>
&nbsp;<asp:LinkButton ID="lkbSearch" runat="server" CssClass="textLink" 
        onclick="lkbSearch_Click">Pesquisa</asp:LinkButton>
    <br />
</div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados</div>
    </div>
            <div class="divContentFields">
                <asp:GridView ID="gvResult" runat="server" CellPadding="4" CellSpacing="1" 
        CssClass="textLabel" ForeColor="#333333" GridLines="None" 
    AutoGenerateColumns="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="InternalNumber" HeaderText="N.Interno" 
                HtmlEncode="false" >
                <ItemStyle VerticalAlign="Top" Font-Bold="true" Font-Size="10" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="ProcessNumber" HeaderText="N.Processo" 
                HtmlEncode="false" >
                <ItemStyle VerticalAlign="Top" Font-Bold="true" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="Creditor" HeaderText="Exequente" HtmlEncode="false" >
                <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="Executed" HeaderText="Executado" HtmlEncode="false" >
                <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="Obs" HeaderText="Informações" HtmlEncode="false" >
                <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="Files" HeaderText="Ficheiros" HtmlEncode="false" >
                <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
        <br />
        <asp:LinkButton ID="lkbPrev" runat="server" onclick="lkbPrev_Click" 
            CssClass="textLink">&lt; Anterior</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="lkbNext" runat="server" onclick="lkbNext_Click" 
            CssClass="textLink">Próximo &gt;</asp:LinkButton>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

