<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.ProcessEPayment" Codebehind="ProcessEPayment.aspx.cs" %>

<%@ Register src="wucAppKey.ascx" tagname="wucAppKey" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divContentTitle">
        <div class="divContent">
            1. Opções de Pesquisa - Pagamentos Processos Executivos</div>
    </div>
    <div class="divContentFields">
        <uc1:wucAppKey ID="wucAppKey1" runat="server" Visible="false" />
        <asp:Label ID="Label1" runat="server" Text="Num Interno"></asp:Label>
        <asp:TextBox ID="txtInternalCode" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Num Tribunal"></asp:Label>
        <asp:TextBox ID="txtProcessNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label ID="Label31" runat="server" Text="Data"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server" CssClass="textTextBox"></asp:TextBox>
        <br />
        <asp:Label ID="Label32" runat="server" Text="Total"></asp:Label>
        <asp:TextBox ID="txtTotal" runat="server" CssClass="textTextBox">0</asp:TextBox>
        <asp:Label ID="Label34" runat="server" Text="Recibo/Factura"></asp:Label>
        <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
        &nbsp;<asp:Label ID="Label33" runat="server" Text="Tipo Pagamento"></asp:Label>
        <asp:DropDownList CssClass="textLabelB" ID="cmbPaymentType" runat="server">
            <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
            <asp:ListItem Value="1" Text="Provisao"></asp:ListItem>
            <asp:ListItem Value="2" Text="Penhora Vencimento"></asp:ListItem>
            <asp:ListItem Value="3" Text="Penhora Créditos"></asp:ListItem>
            <asp:ListItem Value="4" Text="Pagamento Prestações"></asp:ListItem>
            <asp:ListItem Value="5" Text="Pagamento Integrais"></asp:ListItem>
            <asp:ListItem Value="6" Text="Penhora Saldos Bancários"></asp:ListItem>
            <asp:ListItem Value="7" Text="Outros"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:ImageButton ID="imgBtSearch" runat="server" ImageUrl="~/images/webapp/icons/search.png"
            OnClick="imgBtSearch_Click" />
        <br />
        <br />
        <asp:Label ID="lblTotalInfo" runat="server"></asp:Label>
    </div>
    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados </div>
    </div>
    <div class="divContentFields">
        <asp:GridView ID="gvResult" runat="server" CellPadding="4" CellSpacing="1" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" CssClass="textLabel" OnRowCreated="gvResult_RowCreated"
            OnRowCommand="gvResult_RowCommand" OnRowDataBound="gvResult_RowDataBound" EmptyDataText="Sem Resultados.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField HeaderText="Num Interno" DataField="InternalNumber" />
                <asp:BoundField HeaderText="Num Tribunal" DataField="ProcessNumber" />
                <asp:BoundField HeaderText="Data" DataField="Date" />
                <asp:BoundField HeaderText="Total" DataField="Total" 
                    DataFormatString="{0:0.00} €" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Despesa" DataField="OutCome" 
                    DataFormatString="{0:0.00} €" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Honorario" DataField="InCome" 
                    DataFormatString="{0:0.00} €" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Tipo pagamento" DataField="PaymentType" />
                <asp:BoundField HeaderText="Descrição pagamento" DataField="PaymentFor" />
                <asp:BoundField HeaderText="Recibo/Factura" DataField="InvoiceNumber" />
                <asp:BoundField HeaderText="Observaçao" DataField="Observation" />
                <asp:BoundField DataField="status" HeaderText="_estado" />
                <asp:BoundField DataField="RetentionValue" HeaderText="Retenção" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text="Recibo/Factura"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Observação"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtObservation" runat="server" Text='<%# Bind("Observation") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtPay" OnClientClick="return YesNo();" CommandName="pay"
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apagar">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtDel" ImageUrl="~/images/webapp/icons/delete.png" OnClientClick="return YesNo();"
                            CommandName="del" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
</asp:Content>
