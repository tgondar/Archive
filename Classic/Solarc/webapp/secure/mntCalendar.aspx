<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.mntCalendar" Codebehind="mntCalendar.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="float:left;">
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </div>
    <div style="float:left;">
        Items <asp:DropDownList runat="server" ID="cmbItems">
            <asp:ListItem Text="Activos" Value="1"></asp:ListItem>
            <asp:ListItem Text="Inactivos" Value="0"></asp:ListItem>
            <asp:ListItem Text="Expirados" Value="2"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:LinkButton ID="lkbSearch" runat="server" onclick="lkbSearch_Click">Pesquisar</asp:LinkButton>
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowcommand="gvResult_RowCommand" onrowcreated="gvResult_RowCreated" 
            onrowdatabound="gvResult_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbChecked" runat="server" CommandName="checked"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date" HeaderText="Data" />
                <asp:BoundField DataField="CreateUser" HeaderText="Utilizador" />
                <asp:BoundField DataField="Observation" HeaderText="Observacao" />
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
    </div>
    <br />
</asp:Content>
