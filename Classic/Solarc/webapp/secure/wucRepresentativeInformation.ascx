<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucRepresentativeInformation"
    CodeBehind="wucRepresentativeInformation.ascx.cs" %>
<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server"
    DisplayAfter="100">
    <ProgressTemplate>
        <div style="background-color: Red; padding: 10px; color: White;">
            <img src="../../images/webapp/loading.gif" alt="loading" />
            A processar...</div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="txtRepresentativeInformation" runat="server" CssClass="textTextBox"
            Width="500px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtRepresentativeInformation" ErrorMessage="*" 
            ValidationGroup="Add"></asp:RequiredFieldValidator>
        &nbsp;<asp:CheckBox ID="ckbNotifyRepresentative" runat="server" Text="Notificar Mandatário" />
        &nbsp;<asp:ImageButton ID="imgBtInsertRepresentativeInformation" runat="server" ImageUrl="~/images/webapp/icons/add.png"
            OnClick="imgBtInsertRepresentativeInformation_Click" 
            ValidationGroup="Add" />
        <asp:ImageButton ID="imgBtSaveRepresentativeInformation" runat="server" ImageUrl="~/images/webapp/icons/save.png"
            OnClick="imgBtSaveRepresentativeInformation_Click" Visible="False" 
            ValidationGroup="Add" />
        &nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="gvRepresentativeInformation" runat="server" AutoGenerateColumns="False"
            CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None" OnRowDeleting="gvRepresentativeInformation_RowDeleting"
            Width="100%" OnSelectedIndexChanged="gvRepresentativeInformation_SelectedIndexChanged">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField SelectText="Editar" ShowSelectButton="True" ButtonType="Image"
                    SelectImageUrl="~/images/webapp/icons/edit.png" />
                <asp:BoundField DataField="Date" HeaderText="Data">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Information" HeaderText="Informação" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Left" Width="100%" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CommandField DeleteText="Apagar" ShowDeleteButton="True" ButtonType="Image"
                    DeleteImageUrl="~/images/webapp/icons/filedelete.png" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
