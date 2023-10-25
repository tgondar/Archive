<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucProcessDetails"
    CodeBehind="wucProcessDetails.ascx.cs" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <div style="background-color:Red; height: 20px; padding:0 0 0 20px; color:#ffffff;">
            <img src="../../images/webapp/loading.gif" /> A Processar...</div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div style="margin:0 0 10px 0;">
        <div class="divErro">
            <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    </div>

    <div class="textProcessColumns" style="text-align:left; width:100%;">
        <div style="float:left; margin:0 10px 15px 0;">
            Acordo Pagamento<br />
            <asp:DropDownList CssClass="textLabelB" ID="cmbPaymentAgreement" runat="server" 
                Width="100px">
            </asp:DropDownList>
        </div>
        <div style="float:left; margin:0 10px 15px 0;">
            Extinção Processo<br />
            <asp:DropDownList CssClass="textLabelB" ID="cmbProcessExtinction" 
                runat="server" Width="400px">
            </asp:DropDownList>
        </div>
        <div style="float:left; margin:0 10px 15px 0;">
            Código Extinção<br />
            <asp:DropDownList CssClass="textLabelB" ID="cmbExtinctionCode" runat="server" 
                Width="100px">
            </asp:DropDownList>
        </div>
        <div style="float:left; margin:0 10px 15px 0;">
            Diligências no Local<br />
            <asp:DropDownList CssClass="textLabelB" ID="cmbArrangementsInPlace" runat="server" Width="200px">
            </asp:DropDownList>
        </div>
    </div>
<img alt="spacer" src="../../images/spacer.png" height="5" width="100%" />
<div class="textProcessColumns" style="text-align:left; width:100%; margin:0 0 10px 0;">
    <div style="float:left; margin:0 10px 10px 0;">
        Em Penhora<br />
        <asp:DropDownList CssClass="textLabelB" ID="cmbInAttachment" runat="server" Width="200px">
            <asp:ListItem Text="-" Value="0"></asp:ListItem>
            <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
            <asp:ListItem Text="Não" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div style="float:left; margin:0 10px 15px 0;">
        Estado Processo<br />
        <asp:DropDownList CssClass="textLabelB" ID="cmbProcessState" runat="server" Width="200px">
        </asp:DropDownList>
    </div>
    <div style="float:left; margin:0 10px 15px 0;">
        Consulta Base de Dados<br />
        <asp:DropDownList CssClass="textLabelB" ID="cmbDBInfo" runat="server" Width="200px">
        </asp:DropDownList>
    </div>
    <div style="float:left; margin:0 10px 20px 0;">
        Certidão Incobrabilidade<br />
        <asp:DropDownList CssClass="textLabelB" ID="cmbUncollectabilityCertificate" runat="server" Width="200px">
        </asp:DropDownList>
    </div>
</div>
<div style="clear:both;"></div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div style="text-align:left;">
            <div style="float:left; margin:0 10px 15px 0;">
                <asp:Label ID="Label2" runat="server" Text="Provisão" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtProvision" runat="server" CssClass="textTextBox" MaxLength="10"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 15px 0;">
                <asp:Label ID="Label3" runat="server" Text="Data Recepção Provisão" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtProvisionReceptionDate" runat="server" 
                    CssClass="textTextBox" MaxLength="10" ToolTip="dd-mm-aaaa"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 15px 0;">
                <asp:Label ID="Label4" runat="server" Text="Aguarda Pagamento Factura" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtPendingInvoicePayment" runat="server" CssClass="textTextBox" MaxLength="10"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 15px 0;">
                <asp:Label ID="Label7" runat="server" Text="Data Pagamento Factura" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtPendingInvoicePaymentDate" runat="server" 
                    CssClass="textTextBox" MaxLength="10" ToolTip="dd-mm-aaaa"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 15px 0;">
                <asp:Label ID="Label5" runat="server" Text="Localidade da Diligência" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtDiligenceLocation" runat="server" CssClass="textTextBox" MaxLength="50"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 5px 0;">
                <asp:Label ID="Label6" runat="server" Text="Fase Judicial" CssClass="textProcessColumns"></asp:Label><br />
                <asp:DropDownList ID="cmbJudicialPhase" runat="server" CssClass="textLabelB">
                    <asp:ListItem Text="-" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Declarativa" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Desistência" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Executiva" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="float:left; margin:0 10px 5px 0;">
                <asp:Label ID="Label90" runat="server" Text="Ref. Processo Exequente" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtCreditorReference" CssClass="textTextBox"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 5px 0;">
                <asp:Label ID="Label91" runat="server" Text="Data Aceitação" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtAcceptDate" runat="server" CssClass="textTextBox"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 10px 0;">
                <asp:Label ID="Label92" runat="server" Text="Data Rec. Duplicados" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtDuplicatesReceipt" runat="server" CssClass="textTextBox"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 10px 0;">
                <asp:Label ID="Label94" runat="server" Text="Alerta Num.Dias" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtAlert" runat="server" CssClass="textTextBox" Width="70" 
                    ToolTip="0 para desactivar o alerta"></asp:TextBox>
            </div>
            <div style="float:left; margin:0 10px 5px 0;">
                <asp:Label ID="Label93" runat="server" Text="Informações do Juiz" CssClass="textProcessColumns"></asp:Label><br />
                <asp:TextBox ID="txtJudgeObservation" Width="900px" MaxLength="4000" 
                    runat="server" CssClass="textTextBox" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<div style="clear:both;"></div>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnDelegate" runat="server">
        <div style="padding:10px 0 0 0; text-align:left;">
            <div style=" margin:0 0 10px 0;">
                <asp:Label ID="Label1" runat="server" Text="Delegado" 
                    CssClass="textProcessColumns"></asp:Label>
                &nbsp;<asp:DropDownList ID="cmbDelegate" runat="server" CssClass="textLabelB"></asp:DropDownList>
                &nbsp;<asp:TextBox ID="txtObservation" runat="server" MaxLength="4000" 
                    Width="500px" CssClass="textTextBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtObservation" ErrorMessage="*" SetFocusOnError="True" 
                    ValidationGroup="AddSave"></asp:RequiredFieldValidator>
                <asp:ImageButton ID="imgBtAdd"
                    runat="server" ImageUrl="~/images/webapp/icons/add.png" 
                    ToolTip="Adicionar Delegado e Informação" onclick="imgBtAdd_Click" 
                    ValidationGroup="AddSave" />
                <asp:ImageButton ID="imgBtSave" 
                    runat="server" ImageUrl="~/images/webapp/icons/save.png" 
                    ToolTip="Gravar Alteração" Visible="False" onclick="imgBtSave_Click" 
                    ValidationGroup="AddSave" />
            </div>

            <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None" 
                onselectedindexchanged="gvResult_SelectedIndexChanged" 
                CssClass="textLabel" onrowcommand="gvResult_RowCommand" 
                onrowcreated="gvResult_RowCreated">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:CommandField ButtonType="Image" HeaderText="Editar" 
                        SelectImageUrl="~/images/webapp/icons/edit.png" ShowSelectButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Delegado">
                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Observation" HeaderText="Obs">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="100%" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtDelete" runat="server" OnClientClick="return YesNo();" CommandName="del" ToolTip="Apagar" ImageUrl="~/images/webapp/icons/filedelete.png" />
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

