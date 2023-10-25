<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucPEPayment"
    CodeBehind="wucPEPayment.ascx.cs" %>
<p>
    <b>Recebido:</b>
    <asp:Label ID="lblPayed" runat="server"></asp:Label>
    &nbsp;
    <b>Em Falta:</b>
    <asp:Label ID="lblNotPayed" runat="server"></asp:Label>
    &nbsp;
    <b>Total:</b>
    <asp:Label ID="lblTotal" runat="server"></asp:Label>
    &nbsp;
    <b>Provisão:</b>
    <asp:Label ID="lblProvision" runat="server"></asp:Label>
</p>

<div style="padding:3px;">
    <b>Adicionar pagamento</b>
    <div style=" padding:3px;">
        Tipo pagamento 
        <asp:DropDownList CssClass="textLabelB" ID="cmbPaymentType" runat="server" OnSelectedIndexChanged="cmbPaymentType_SelectedIndexChanged"
            AutoPostBack="True">
            <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
            <asp:ListItem Value="1" Text="Provisao"></asp:ListItem>
            <asp:ListItem Value="2" Text="Penhora Vencimento"></asp:ListItem>
            <asp:ListItem Value="3" Text="Penhora Créditos"></asp:ListItem>
            <asp:ListItem Value="4" Text="Pagamento Prestações"></asp:ListItem>
            <asp:ListItem Value="5" Text="Pagamento Integrais"></asp:ListItem>
            <asp:ListItem Value="6" Text="Penhora Saldos Bancários"></asp:ListItem>
            <asp:ListItem Value="7" Text="Outros"></asp:ListItem>
            <asp:ListItem Value="8" Text="Valor Transferido"></asp:ListItem>
        </asp:DropDownList>


        <asp:DropDownList CssClass="textLabelB" ID="cmb2" runat="server" AutoPostBack="True" 
            onselectedindexchanged="cmb2_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList CssClass="textLabelB" ID="cmb3" runat="server">
        </asp:DropDownList>
    </div>
    <div style=" padding:3px;">
        <asp:Label ID="Label1" runat="server" Text="Despesa"></asp:Label>
        <asp:TextBox CssClass="textTextBox" ID="txtOutCome" runat="server" Width="50px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Honorario"></asp:Label>
        <asp:TextBox CssClass="textTextBox" ID="txtInCome" runat="server" Width="50px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Iva"></asp:Label>
        <asp:TextBox CssClass="textTextBox" ID="txtVat" runat="server" Width="23px"></asp:TextBox>
        &nbsp;<asp:Label ID="lblRetain" runat="server" Text="Retenção"></asp:Label>
        <asp:TextBox CssClass="textTextBox" ID="txtRetain" runat="server" Width="28px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label5" runat="server" Text="Data"></asp:Label>
        <asp:TextBox CssClass="textTextBox" ID="txtPaymentDate" runat="server" 
            Width="70px"></asp:TextBox>
    </div>
    <asp:Label ID="Label4" runat="server" Text="Obs"></asp:Label>
    <asp:TextBox CssClass="textTextBox" ID="txtObservation" runat="server" Width="497px"></asp:TextBox>
    <br />
    <br />
    <span class="PaymentButton"><asp:LinkButton CssClass="textLink" ID="lkbAddPayment" runat="server" OnClick="lkbAddPayment_Click">Adicionar</asp:LinkButton></span> 
    <span class="PaymentButton">
        <asp:TextBox CssClass="textTextBox" ID="txtMonths" runat="server" Width="39px"></asp:TextBox>
        &nbsp;<asp:LinkButton CssClass="textLink" ID="lkbAddMonths" runat="server" onclick="lkbAddMonths_Click" 
            onclientclick="return YesNo();">Adicionar Mensalidade(s)</asp:LinkButton>
    </span>
</div>

<br />
<asp:Label ID="lblInfo" runat="server"></asp:Label>
<br />
<asp:GridView ID="gvResult" runat="server" CellPadding="4" CellSpacing="1" 
    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
    onselectedindexchanged="gvResult_SelectedIndexChanged" 
    CssClass="textLabelB">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:BoundField DataField="Date" HeaderText="Data" />
        <asp:BoundField DataField="PaymentType" HeaderText="Tipo Pagamento" />
        <asp:BoundField DataField="PaymentFor" HeaderText="Para quem" />
        <asp:BoundField DataField="Total" DataFormatString="{0:0.00} €" HeaderText="Valor(total)" />
        <asp:TemplateField HeaderText="NumRecibo/Factura">
            <ItemTemplate>
                <asp:TextBox CssClass="textTextBox" ID="txtInvoiceNumber" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Obs">
            <ItemTemplate>
                <asp:TextBox CssClass="textTextBox" ID="txtObservation" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Text='<%# Bind("Observation") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField HeaderText="Pago?" SelectText="Não" ShowSelectButton="True">
        <ItemStyle Font-Bold="True" ForeColor="Red" />
        </asp:CommandField>
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<br />


<asp:HyperLink ID="hlPayment" runat="server">Todos pagamentos do processo.</asp:HyperLink>


