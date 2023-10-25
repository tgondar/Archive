<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucProcessFiles"
    CodeBehind="wucProcessFiles.ascx.cs" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server" DisplayAfter="100">
            <ProgressTemplate><div style=" background-color:Red; padding:10px; color:White;"><img src="../../../images/webapp/loading.gif" alt="loading" /> A processar...</div></ProgressTemplate>
        </asp:UpdateProgress>
                <asp:Label ID="label20" CssClass="textLabel" runat="server" Text="Seleccione o ficheiro para enviar"></asp:Label>&nbsp;<input id="uploadform" runat="server" type="file" class="textLabelB"  /><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="uploadform" 
                ErrorMessage="*" ValidationGroup="upload" 
                CssClass="textError" ></asp:RequiredFieldValidator>
                &nbsp;<asp:CheckBoxList ID="cklPermissions" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="textLabel">
                </asp:CheckBoxList>
                &nbsp;<asp:ImageButton ID="imgBtSend" runat="server" 
                    ImageUrl="~/images/webapp/icons/enviar.png" 
            onclick="imgBtSend_Click" />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="divErro"><asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
                <asp:GridView ID="gvResultFiles" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None" 
                    onrowcommand="gvResult_RowCommand" onrowcreated="gvResult_RowCreated"
                     OnRowDataBound="gvResult_RowDataBound" Width="100%" CssClass="textLabelB">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Nome Ficheiro" />
                        <asp:TemplateField HeaderText="Utilizadores">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtSaveUserPermission" CommandName="userok" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mandatários">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtSaveRepresentativePermission" CommandName="representativeok" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtDelete" ImageUrl="~/images/webapp/icons/filedelete.png" CommandName="del" runat="server" OnClientClick="return YesNo();" />
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
                <br />
                <asp:Label runat="server" ID="lblInfo" CssClass="textLabel"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblFiles" CssClass="textLabel"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="imgBtSend"/>
            </Triggers>
        </asp:UpdatePanel>
    </ContentTemplate>
</asp:UpdatePanel>
