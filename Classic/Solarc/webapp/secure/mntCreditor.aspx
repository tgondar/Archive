<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntCreditor" Codebehind="mntCreditor.aspx.cs" %>

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
                ID="txtName" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                    ID="Label2" runat="server" Text="Morada" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                        ID="txtAddress" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                            ID="Label3" runat="server" Text="Tlf" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                ID="txtPhone" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                                    ID="Label10" runat="server" Text="Tlm" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                        ID="txtMPhone" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                                            ID="Label4" runat="server" Text="Fax" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                                ID="txtFax" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                                                    ID="Label5" runat="server" Text="Email" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                                        ID="txtEmail" runat="server" CssClass="textTextBox"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                CssClass="textError" ErrorMessage="*" ForeColor="" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="InsertSave"></asp:RegularExpressionValidator>
            &nbsp;<asp:Label ID="Label6" runat="server" Text="BI" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                ID="txtIdentityCard" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                    ID="Label7" runat="server" Text="NIF/NIPC" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                        ID="txtNifNipl" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                            ID="Label8" runat="server" Text="NISS" CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                ID="txtNifs" runat="server" CssClass="textTextBox"></asp:TextBox>&nbsp;<asp:Label
                                    ID="Label9" runat="server" Text="Data Nasc." CssClass="textLabel"></asp:Label>&nbsp;<asp:TextBox
                                        ID="txtBornDate" runat="server" CssClass="textTextBox" Width="75px"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtBornDate"
                CssClass="textError" ErrorMessage="*" ForeColor="" Operator="DataTypeCheck" SetFocusOnError="True"
                Type="Date" ValidationGroup="InsertSave"></asp:CompareValidator>
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
       <asp:GridView ID="gvCreditor" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CellSpacing="1" CssClass="textLabel" ForeColor="#333333" GridLines="None" 
            OnSelectedIndexChanged="gvCreditor_SelectedIndexChanged">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                <asp:BoundField DataField="name" HeaderText="Nome" HtmlEncode="False" />
                <asp:BoundField DataField="Address" HeaderText="Morada" HtmlEncode="False" />
                <asp:BoundField DataField="phone" HeaderText="Tlf" HtmlEncode="False" />
                <asp:BoundField DataField="MPhone" HeaderText="Tlm" />
                <asp:BoundField DataField="fax" HeaderText="Fax" HtmlEncode="False" />
                <asp:BoundField DataField="email" HeaderText="Email" HtmlEncode="False" />
                <asp:BoundField DataField="identitycard" HeaderText="BI" HtmlEncode="False" />
                <asp:BoundField DataField="nifnipl" HeaderText="NIF/NIPC" HtmlEncode="False" />
                <asp:BoundField DataField="nifs" HeaderText="NISS" HtmlEncode="False" />
                <asp:BoundField DataField="borndate" HeaderText="DataNasc" HtmlEncode="False" />
                <asp:BoundField DataField="alteruser" HeaderText="Utilizador" />
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
        <asp:LinkButton ID="lkbPrev" runat="server" onclick="lkbPrev_Click" 
            CssClass="textLink">&lt; Anterior</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lkbNext" runat="server" onclick="lkbNext_Click" 
            CssClass="textLink">Próximo &gt;</asp:LinkButton>
    </div>
        <br /><br />
</asp:Content>

