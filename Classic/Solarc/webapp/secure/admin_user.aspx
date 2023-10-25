<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.admin_user" Codebehind="admin_user.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divErro"><asp:Literal ID="ltMsg" runat="server">lalala</asp:Literal></div>
    <div class="divContentTitle">
        <div class="divContent">1. Criar Utilizador</div>
    </div>
    <div class="divContentFields">
        <asp:Label ID="Label1" runat="server" Text="Utilzador" CssClass="textLabel"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="textTextBox" 
                Width="76px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label2" runat="server" Text="Password" 
                CssClass="textLabel"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="textTextBox" 
                Width="76px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Email" CssClass="textLabel"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="textTextBox" Width="76px"></asp:TextBox>
            &nbsp;<asp:Label ID="Label4" runat="server" Text="Grupo" CssClass="textLabel"></asp:Label>
            <asp:DropDownList ID="cmbRole" runat="server" CssClass="textTextBox" 
                onselectedindexchanged="cmbRole_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Text="Administrador" Value="Administrator"></asp:ListItem>
                <asp:ListItem Text="Mandatário" Value="Representative"></asp:ListItem>
                <asp:ListItem Text="Utilizador" Value="User"></asp:ListItem>
                <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="lblRepresentative" runat="server" Text="Mandatário" 
                CssClass="textLabel" Visible="False"></asp:Label>
            <asp:DropDownList ID="cmbRepresentative" runat="server" CssClass="textTextBox" 
                Visible="False" 
                onselectedindexchanged="cmbRepresentative_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;<asp:CheckBox ID="ckbRepresentative" runat="server" CssClass="textLabel" 
                Text="Notificar por email" Visible="False" />
            &nbsp;<asp:LinkButton ID="lkbAddUser" runat="server" CssClass="textLink" OnClick="lkbAddUser_Click">Adicionar</asp:LinkButton>
        </div>
    <div class="divContentTitle">
        <div class="divContent">2. Utilizadores</div>
     </div>
    <div class="divContentFields">
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" OnRowCommand="gvusers_RowCommand" OnRowCreated="gvusers_RowCreated"
            CellSpacing="1" CssClass="textLabel" 
            onrowdatabound="gvResult_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvResult_PageIndexChanging" PageSize="20">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="username" ReadOnly="True" HtmlEncode="False" 
                    HeaderText="Utilizador" />
                <asp:BoundField DataField="Email" HtmlEncode="False" HeaderText="Email" />
                <asp:BoundField DataField="isapproved" HeaderText="Aprovado?" />
                <asp:BoundField DataField="islockedout" HeaderText="Bloqueado?" />
                <asp:BoundField DataField="isonline" HeaderText="Online?" />
                <asp:BoundField DataField="lastlogindate" HeaderText="Ultimo Login" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbactuser" Text="Activar" runat="server" CommandName="act" CssClass="textLinkB"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lkbdeluser" Text="Apagar" runat="server" CommandName="del"
                            CssClass="textLinkB" OnClientClick="return YesNo();"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="txtPassword" runat="server" BorderColor="Black" BorderStyle="Solid"
                            BorderWidth="1px" CssClass="textTextBox" Width="78px"></asp:TextBox>
                        &nbsp;<asp:LinkButton ID="lkbSetPassword" runat="server" CssClass="textLinkB" CommandName="newpass">Password</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lkbSetEmail" runat="server" CommandName="newemail" CssClass="textLinkB">Email</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lkbSendAccountInformation" runat="server" CommandName="sendaccountinformation" CssClass="textLinkB">Enviar Email</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Grupo">
                    <ItemTemplate>
                        <asp:DropDownList ID="cmbRole" runat="server">
                            <asp:ListItem Text="-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Administrador" Value="Administrator"></asp:ListItem>
                            <asp:ListItem Text="Mandatário" Value="Representative"></asp:ListItem>
                            <asp:ListItem Text="Utilizador" Value="User"></asp:ListItem>
                            <asp:ListItem Text="Cliente" Value="Cliente"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:LinkButton ID="lkbRole" runat="server" CssClass="textLinkB" CommandName="Role">Defenir</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
