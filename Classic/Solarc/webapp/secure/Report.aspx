<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.Report" Codebehind="Report.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    <div class="divContentTitle">
        <div class="divContent">
            1. Opções de Pesquisa</div>
    </div>
    <div class="divContentFields">
        <asp:Label ID="Label1" CssClass="textLabel" runat="server" Text="Num Interno"></asp:Label>
        <asp:TextBox ID="txtInternalNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label ID="Label6" CssClass="textLabel" runat="server" Text="Data"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label CssClass="textLabel" ID="Label2" runat="server" Text="Valor"></asp:Label>
        <asp:TextBox ID="txtValue" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label CssClass="textLabel" ID="Label3" runat="server" Text="Tipo Pagamento"></asp:Label>
        <asp:TextBox ID="txtPaymentType" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<br />
        <asp:Label CssClass="textLabel" ID="Label4" runat="server" Text="Mandatário"></asp:Label>
        <asp:TextBox ID="txtRepresentative" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label ID="Label5" CssClass="textLabel" runat="server" Text="Executado"></asp:Label>
        <asp:TextBox ID="txtExecuted" runat="server" CssClass="textTextBox"></asp:TextBox>

        &nbsp;<asp:Label ID="Label8" CssClass="textLabel" runat="server" Text="Ent. Patronal"></asp:Label>
        <asp:TextBox ID="txtEmployer" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label ID="Label9" runat="server" Text="Invoice Number"></asp:Label>
        <asp:TextBox ID="txtInvoiceNumber" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:LinkButton ID="lkbSearch" runat="server" CssClass="textLink"
            ValidationGroup="search" onclick="lkbSearch_Click">Pesquisa</asp:LinkButton>
        <br />
    </div>
    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados</div>
    </div>
    <div class="divContentFields">
        <asp:GridView ID="gvResult" runat="server" CellPadding="4" CellSpacing="1" CssClass="textLabel"
            ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="InternalNumber" HeaderText="Numero Interno" />
                <asp:BoundField DataField="Date" HeaderText="Data" />
                <asp:BoundField DataField="Executed" HeaderText="Executado" />
                <asp:BoundField DataField="PaymentType" HeaderText="Tipo Pagamento" />
                <asp:BoundField DataField="Value" HeaderText="Valor" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Account" HeaderText="Conta" />
                <asp:BoundField DataField="Representative" HeaderText="Mandatário" />
                <asp:BoundField DataField="Employer" HeaderText="Ent. Patronal" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <asp:LinkButton ID="lkbPrevious" runat="server" CssClass="textLink" Visible="False">&lt; Anterior</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="lkbNext" runat="server" CssClass="textLink" Visible="False">Seguinte &gt;</asp:LinkButton>
        &nbsp;<asp:Label ID="lblInfoReg" runat="server" CssClass="textLabel"></asp:Label>
    </div>
    <br />
    <br />
</asp:Content>
