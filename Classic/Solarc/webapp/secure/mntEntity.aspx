<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntEntity" Codebehind="mntEntity.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
    </div>
    <div class="divContentTitle">
        <div class="divContent">
            1. Pesquisa
        </div>
    </div>
    <div class="divContentFields">
        Código <asp:TextBox ID="txtCode" runat="server"></asp:TextBox> Nome <asp:TextBox ID="txtName" runat="server"></asp:TextBox> BI <asp:TextBox ID="txtIdentityCard" runat="server"></asp:TextBox> 
        Tlm <asp:TextBox ID="txtMPhone" runat="server"></asp:TextBox> Tlf <asp:TextBox ID="txtHPhone" runat="server"></asp:TextBox>
        <br />
        Fax <asp:TextBox ID="txtFax" runat="server"></asp:TextBox> Email <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        Contacto <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox> Activo <asp:CheckBox ID="cbActive" runat="server" /> NIF <asp:TextBox ID="txtTaxNumber" runat="server"></asp:TextBox> 
        <br />
        Morada <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox> 
        C.P. <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox> Observação <asp:TextBox ID="txtObservation" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btSearch" runat="server" Text="Procurar" OnClick="btSearch_Click" />
&nbsp;<asp:Button ID="btAdd" runat="server" Text="Inserir" OnClick="btAdd_Click" />
    &nbsp;<asp:Button ID="btSave" runat="server" OnClick="btSave_Click" Text="Gravar" Visible="False" />
    </div>

    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados
        </div>
    </div>

    <div id="table">
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvResult_RowDeleting" OnSelectedIndexChanged="gvResult_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Code" HeaderText="Codigo" />
                <asp:BoundField DataField="Name" HeaderText="Nome" />
                <asp:BoundField DataField="ContactName" HeaderText="N. Contacto" />
                <asp:BoundField DataField="MPhone" HeaderText="Tlm" />
                <asp:BoundField DataField="HPhone" HeaderText="Tlf" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="AlterDate" HeaderText="DataAlteracao" />
                <asp:BoundField DataField="AlterUser" HeaderText="Utilizador" />
                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                <asp:CommandField DeleteText="Apagar" ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
