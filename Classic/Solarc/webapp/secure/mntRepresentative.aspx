<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" ValidateRequest="false" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntRepresentative" Codebehind="mntRepresentative.aspx.cs" %>

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
            ID="txtName" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;
            <asp:Label ID="lblLawyerNumber" runat="server" Text="Nº Cédula" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                ID="txtLawyerNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
            <asp:Label
                ID="Label2" runat="server" Text="Morada" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                    ID="txtAddress" runat="server" CssClass="textTextBox"></asp:TextBox>
                    &nbsp;<asp:Label
                        ID="Label3" runat="server" Text="Tlf" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                            ID="txtPhone" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<br />
                            <asp:Label ID="Label4" runat="server" Text="Fax" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                    ID="txtFax" runat="server" CssClass="textTextBox"></asp:TextBox>
                                    &nbsp;<asp:Label
                                        ID="Label5" runat="server" Text="Email" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                            ID="txtEmail" runat="server" CssClass="textTextBox"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            CssClass="textError" ErrorMessage="*" ForeColor="" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ValidationGroup="InsertSave"></asp:RegularExpressionValidator>
        &nbsp;<asp:Label ID="Label6" runat="server" Text="Nif" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
            ID="txtNif" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;
            <asp:Label 
            ID="Label7" runat="server" CssClass="textLabel" Text="CC"></asp:Label>
&nbsp;<asp:TextBox ID="txtCarbonCopy" runat="server" CssClass="textTextBox" 
            ToolTip="Introduza os emails, separados por ;"></asp:TextBox>
        &nbsp;<asp:LinkButton ID="lkbSearch" runat="server" CssClass="textLink" OnClick="lkbSearch_Click">Pesquisar</asp:LinkButton>
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
            CellSpacing="1" CssClass="textLabel" ForeColor="#333333" GridLines="None" 
            OnSelectedIndexChanged="gvResult_SelectedIndexChanged">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Nome" HtmlEncode="False" />
                <asp:BoundField DataField="LawyerNumber" HeaderText="Nº Cédula" HtmlEncode="False" />
                <asp:BoundField DataField="Address" HeaderText="Morada" HtmlEncode="False" />
                <asp:BoundField DataField="Phone" HeaderText="Tlf" HtmlEncode="False" />
                <asp:BoundField DataField="Fax" HeaderText="Fax" HtmlEncode="False" />
                <asp:BoundField DataField="Email" HeaderText="Email" HtmlEncode="False" />
                <asp:BoundField DataField="Nif" HeaderText="Nif" HtmlEncode="False" />
                <asp:BoundField DataField="CarbonCopy" HeaderText="CC" HtmlEncode="False" />
                <asp:BoundField DataField="UserName" HeaderText="Utilizador" HtmlEncode="false" />
                <asp:BoundField DataField="AlterDate" HeaderText="Data" HtmlEncode="false" />
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
            CssClass="textLink">&lt; Anterior</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lkbNext" runat="server" onclick="lkbNext_Click" 
            CssClass="textLink">Próximo &gt;</asp:LinkButton>
    </div>
        <br />
        <br />
</asp:Content>

