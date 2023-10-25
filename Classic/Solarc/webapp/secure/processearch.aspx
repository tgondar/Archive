<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.processearch" Codebehind="processearch.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    <div class="divContentTitle">
        <div class="divContent">
            1. Opções de Pesquisa</div>
    </div>
    <div class="divContentFields">
    <div style="margin:0 0 5px 0;">
        <asp:Label ID="Label1" CssClass="textLabel" runat="server" Text="Num Interno"></asp:Label>
    <asp:TextBox ID="txtInternalNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
    &nbsp;<asp:Label ID="Label6" CssClass="textLabel" runat="server" Text="Num Processo"></asp:Label>
    <asp:TextBox ID="txtProcessNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
    &nbsp;<asp:Label CssClass="textLabel" ID="Label2" runat="server" Text="Tribunal"></asp:Label>
    <asp:TextBox ID="txtCourt" runat="server" CssClass="textTextBox"></asp:TextBox>
    &nbsp;<asp:Label CssClass="textLabel" ID="Label3" runat="server" Text="Exequente"></asp:Label>
    <asp:TextBox ID="txtCreditor" runat="server" CssClass="textTextBox"></asp:TextBox>
    &nbsp;<br />
    </div>



    <div style="margin:0 0 5px 0;">
        <asp:Label CssClass="textLabel" ID="Label4" runat="server" Text="Mandatário"></asp:Label>
    <asp:TextBox ID="txtRepresentative" runat="server" CssClass="textTextBox"></asp:TextBox>
&nbsp;<asp:Label ID="Label5" CssClass="textLabel" runat="server" Text="Executado"></asp:Label>
    <asp:TextBox ID="txtExecuted" runat="server" CssClass="textTextBox"></asp:TextBox>
&nbsp;<asp:Label ID="Label7" runat="server" CssClass="textLabel" Text="N.Dias"></asp:Label>
        &nbsp;<asp:TextBox ID="txtNDays" CssClass="textTextBox" runat="server" MaxLength="4" Width="30px">0</asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txtNDays" ErrorMessage="*" Operator="DataTypeCheck" 
            SetFocusOnError="True" Type="Integer" ValidationGroup="search"></asp:CompareValidator>
&nbsp;<asp:Label ID="Label10" runat="server" Text="Grupo" CssClass="textLabel"></asp:Label>
        <asp:DropDownList ID="cmbGroup" runat="server" CssClass="textTextBox">
        </asp:DropDownList>
&nbsp;<asp:Label ID="Label8" CssClass="textLabel" runat="server" Text="Localização"></asp:Label>
    &nbsp;<asp:TextBox ID="txtLocalization" runat="server" CssClass="textTextBox"></asp:TextBox>
    </div>





        <asp:Label ID="Label9" runat="server" Text="Utilizador" CssClass="textLabel"></asp:Label>
        <asp:DropDownList ID="cmbUser" runat="server" CssClass="textTextBox">
        </asp:DropDownList>
        &nbsp;<asp:Label ID="Label11" runat="server" CssClass="textLabel" 
            Text="Data Inicio"></asp:Label>
        <asp:TextBox ID="txtDate1" runat="server" CssClass="textTextBox" Width="70px"></asp:TextBox>
&nbsp;<asp:Label ID="Label12" runat="server" CssClass="textLabel" Text="Data Fim"></asp:Label>
        <asp:TextBox ID="txtDate2" runat="server" CssClass="textTextBox" Width="70px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label13" runat="server" Text="Provisão"></asp:Label>
        <asp:TextBox ID="txtProvision" runat="server" Width="75px" 
            CssClass="textTextBox">0</asp:TextBox>
&nbsp;<asp:Label ID="Label14" runat="server" Text="Ag.Pag.Fact."></asp:Label>
        <asp:TextBox ID="txtPendingInvoicePayment" runat="server" Width="80px" 
            CssClass="textTextBox">0</asp:TextBox>
        <br /><asp:LinkButton ID="lkbSearch" runat="server" CssClass="textLink" 
        onclick="lkbSearch_Click" ValidationGroup="search">Pesquisa</asp:LinkButton>
    &nbsp;<asp:Label ID="lblSearch" CssClass="textLabel" runat="server"></asp:Label>
    <br />
    </div>
    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados</div>
    </div>
    <div class="divContentFields">
        <asp:GridView ID="gvResult" runat="server" CellPadding="4" CellSpacing="1" 
        CssClass="textLabel" ForeColor="#333333" GridLines="None" 
    AutoGenerateColumns="False" 
    onselectedindexchanged="gvResult_SelectedIndexChanged">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            <asp:BoundField DataField="InternalNumber" HeaderText="N.Interno" HtmlEncode="False" />
            <asp:BoundField DataField="IRS" HeaderText="Penhora DGCI" HtmlEncode="False" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Provision" HeaderText="Provisão" />
            <asp:BoundField DataField="PendingInvoicePayment" HeaderText="Ag. Pag. Fact." />
            <asp:BoundField DataField="Court" HeaderText="Tribunal" />
            <asp:BoundField DataField="Representative" HeaderText="Mandatario" />
            <asp:BoundField DataField="ProcessNumber" HeaderText="N.Processo" />
            <asp:BoundField DataField="Creditor" HeaderText="Exequente" />
            <asp:BoundField DataField="Executed" HeaderText="Executado" />
            <asp:BoundField DataField="Localization" HeaderText="Grupo" >
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="LocalizationDetail" HeaderText="Localização" />
            <asp:BoundField DataField="UserName" HeaderText="Utilizador" />
            <asp:BoundField DataField="AlterDate" HeaderText="DataAlteração" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
<%--        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
--%>
<br />
<asp:LinkButton ID="lkbPrevious" runat="server" CssClass="textLink" 
        onclick="lkbPrevious_Click" Visible="False">&lt; Anterior</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lkbNext" runat="server" 
    CssClass="textLink" onclick="lkbNext_Click" Visible="False">Seguinte &gt;</asp:LinkButton>
&nbsp;<asp:Label ID="lblInfoReg" runat="server" CssClass="textLabel"></asp:Label>
</div>
        <br />
        <br />

    <script type="text/javascript">
        $(function () {
            $("#ContentPlaceHolder1_txtCourt").autocomplete({
                source: function (request, response) {
                    $.getJSON('services/CourtService.svc/GetAutocomplete', request, function (data) {
                        response(data.d);
                    });
                }
            });
        });

        $(function () {
            $("#ContentPlaceHolder1_txtCreditor").autocomplete({
                source: function (request, response) {
                    $.getJSON('services/EntityService.svc/GetCreditor', request, function (data) {
                        response(data.d);
                    });
                }
            });
        });

        $(function () {
            $("#ContentPlaceHolder1_txtExecuted").autocomplete({
                source: function (request, response) {
                    x
                    $.getJSON('services/EntityService.svc/GetExecuted', request, function (data) {
                        response(data.d);
                    });
                }
            });
        });
        $(function () {
            $("#ContentPlaceHolder1_txtRepresentative").autocomplete({
                source: function (request, response) {
                    $.getJSON('services/EntityService.svc/GetRepresentative', request, function (data) {
                        response(data.d);
                    });
                }
            });
        });
    </script>
</asp:Content>

