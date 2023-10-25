<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" ValidateRequest="false"
    MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.process"
    CodeBehind="process.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="wucProcessFiles.ascx" tagname="wucProcessFiles" tagprefix="uc1" %>
<%@ Register src="wucRepresentativeInformation.ascx" tagname="wucRepresentativeInformation" tagprefix="uc2" %>


<%@ Register src="wucPEPayment.ascx" tagname="wucPEPayment" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AC.asmx" />
            <asp:ServiceReference Path="~/AAttachment.asmx" />
            <asp:ServiceReference Path="~/ACreditor.asmx" />
            <asp:ServiceReference Path="~/AExec.asmx" />
            <asp:ServiceReference Path="~/ARepresentative.asmx" />
            <asp:ServiceReference Path="~/ACEmployer.asmx" />
            <asp:ServiceReference Path="~/ACSearch.asmx" />
            <asp:ServiceReference Path="~/ACSection.asmx" />
        </Services>
    </asp:ScriptManager>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" 
        TargetControlID="txtCourtName"
        ServicePath="~/AC.asmx" 
        ServiceMethod="Court" 
        MinimumPrefixLength="2" 
        CompletionInterval="500"
        EnableCaching="true" 
        CompletionSetCount="12" 
        CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" 
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" >
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete2" TargetControlID="txtCreditorName"
        ServicePath="~/ACreditor.asmx" ServiceMethod="Creditor" MinimumPrefixLength="2"
        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete3" TargetControlID="txtExecutedName"
        ServicePath="~/AExec.asmx" ServiceMethod="Executed" MinimumPrefixLength="2" CompletionInterval="500"
        EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete4" TargetControlID="txtRepresentativeName"
        ServicePath="~/ARepresentative.asmx" ServiceMethod="Representative" MinimumPrefixLength="2"
        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete5" TargetControlID="txtAttachment"
        ServicePath="~/AAttachment.asmx" ServiceMethod="Attachment" MinimumPrefixLength="2"
        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete6" TargetControlID="txtEmployerName"
        ServicePath="~/ACEmployer.asmx" ServiceMethod="Employer" MinimumPrefixLength="2"
        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete7" TargetControlID="txtSearchName"
        ServicePath="~/ACSearch.asmx" ServiceMethod="Search" MinimumPrefixLength="2"
        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <cc1:AutoCompleteExtender runat="server" ID="autoComplete8" TargetControlID="txtCourtSection"
        ServicePath="~/ACSection.asmx" ServiceMethod="Section" MinimumPrefixLength="2"
        CompletionInterval="500" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>

    <div class="divErro">
        <asp:Literal ID="ltMsg" runat="server"></asp:Literal></div>
    <table class="BackProcess" align="center" border="0" cellpadding="5" cellspacing="10" width="900px">
        <tr>
            <td colspan="2" class="procNum">
                <asp:Label ID="Label18" runat="server" Text="Nº Interno"></asp:Label>
                &nbsp;<asp:Label ID="lblInternalNumber" runat="server"></asp:Label>
                <asp:TextBox ID="txtInternalNumber" runat="server" CssClass="textTextBox" 
                    Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtInternalNumber" CssClass="textLabel" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="newProcess"></asp:RequiredFieldValidator>
                <asp:ImageButton ID="imgBtChangeInternalNumber" runat="server" 
                    ImageUrl="~/images/webapp/icons/edit.png" 
                    onclick="imgBtChangeInternalNumber_Click" 
                    ToolTip="Editar Codigo Interno" />
                <asp:ImageButton ID="imgBtSaveInternalNumber" runat="server" 
                    ImageUrl="~/images/webapp/icons/save.png" 
                    onclick="imgBtSaveInternalNumber_Click" Visible="False" 
                    ToolTip="Gravar Numero Interno" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                IDENTIFICAÇÃO DO PROCESSO
                <asp:ImageButton ID="imgBtEditProcessIdentification" runat="server" 
                    ImageUrl="~/images/webapp/icons/edit.png" 
                    onclick="imgBtEditProcessIdentification_Click" 
                    ToolTip="Editar Identificacao do Processo" />
                <asp:ImageButton ID="imgBtSaveProcessIdentification" runat="server" 
                    ImageUrl="~/images/webapp/icons/save.png" 
                    onclick="imgBtSaveProcessIdentification_Click" Visible="False" 
                    ToolTip="Gravar Identificacao do Processo" />
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Nº do Processo
            </td>
            <td class="textProcessFields">
                <asp:Label ID="lblProcessNumber" runat="server"></asp:Label>
                <asp:Panel ID="panProcessNumberEdit" runat="server" Visible="False">
                    <asp:TextBox ID="txtProcessNumber" runat="server" CssClass="textTextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtProcessNumber" ErrorMessage="*" SetFocusOnError="True" 
                        ValidationGroup="newProcess"></asp:RequiredFieldValidator>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">IRS
            </td>
            <td class="textProcessFields">
                <input type="text" id="txtIRS" /><input type="button" value="Gravar" onclick="SetIRS()" />
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">Tipo de Execução</td>
            <td class="textProcessFields">
                <asp:Label ID="lblExecutionType" runat="server"></asp:Label>
                <asp:Panel runat="server" ID="pExecutionType" Visible="false">
                    <asp:DropDownList ID="cmbExecutionType" runat="server" CssClass="textLabelB">
                        <asp:ListItem Text="-" Value=""></asp:ListItem>
                        <asp:ListItem Text="Pagamento de Quantia Certa"></asp:ListItem>
                        <asp:ListItem Text="Entrega de Coisa Certa"></asp:ListItem>
                        <asp:ListItem Text="Prestação de Facto"></asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">Localização Processo</td>
            <td class="textProcessFields">
                <asp:Label ID="lblLocalization" runat="server"></asp:Label>
                &nbsp;-
                <asp:Label ID="lblLocalizationDetail" runat="server"></asp:Label>
                <asp:Panel ID="panLocalization" runat="server" Visible="False">
                    <asp:DropDownList ID="cmbLocalization" runat="server" CssClass="textLabelB">
                    </asp:DropDownList>
                    &nbsp;-
                    <asp:TextBox ID="txtLocalizationDetail" runat="server" CssClass="textTextBox" 
                        MaxLength="1000" Width="200px"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">Título Executivo</td>
            <td class="textProcessFields">
                <asp:Label ID="lblEnforcement" runat="server"></asp:Label>
                <asp:Panel ID="panEnforcement" runat="server" Visible="False">
                    <asp:TextBox ID="txtEnforcement" runat="server" CssClass="textTextBox" 
                        MaxLength="50"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Tribunal
            </td>
            <td class="textProcessFields">
                <asp:Label ID="lblCourt" runat="server"></asp:Label>
                <asp:Panel ID="panCourtEdit" runat="server" Visible="False">
                    <asp:TextBox ID="txtCourtName" runat="server" autocomplete="off" 
                        CssClass="textTextBox" MaxLength="100" Width="150px"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="imgBtCourtEditInfo" runat="server" 
                        ImageUrl="~/images/webapp/icons/edit.png" 
                        onclick="imgBtCourtEditInfo_Click" ToolTip="Editar Tribunal" />
                    <asp:ImageButton ID="imgBtCourtProcessInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/add.png" 
                        onclick="imgBtCourtProcessInsert_Click" 
                        ToolTip="Adicionar Tribunal ao Processo" />
                    <asp:ImageButton ID="imgBtCourtInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/new.png" 
                        onclick="imgBtCourtInsert_Click" ToolTip="Novo Tribunal" />
                    <br />
                    <asp:Panel ID="panCourtEditInfo" runat="server" Visible="False" 
                        CssClass="panelEdit" ToolTip="Cancelar">
                        <asp:Label ID="Label41" runat="server" Text="Secção" CssClass="panelEditLabel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCourtSection" runat="server" CssClass="textTextBox" MaxLength="50"
                            autocomplete="off"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Morada" CssClass="panelEditLabel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCourtAddress" runat="server" CssClass="textTextBox" 
                            MaxLength="100"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Telefone" CssClass="panelEditLabel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCourtPhone" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Fax" CssClass="panelEditLabel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCourtFax" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Email" CssClass="panelEditLabel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCourtEmail" runat="server" Style="margin-bottom: 0px" 
                            CssClass="textTextBox" MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblCourtJudicialDistrict" runat="server" Text="Comarca" CssClass="panelEditLabel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCourtJudicialDistrict" runat="server" Style="margin-bottom: 0px" 
                            CssClass="textTextBox" MaxLength="50"></asp:TextBox>
                        &nbsp;<asp:ImageButton ID="imgBtCourtEditSave" runat="server" 
                            ImageUrl="~/images/webapp/icons/save.png" 
                            onclick="imgBtCourtEditSave_Click" ToolTip="Gravar" />
                        <asp:ImageButton ID="imgBtCourtCancel" runat="server" 
                            ImageUrl="~/images/webapp/icons/filedelete.png" 
                            onclick="imgBtCourtCancel_Click" ToolTip="Cancelar" />
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Valor
            </td>
            <td class="textProcessFields">
                <asp:Panel ID="panValue" runat="server">
                        <asp:Label ID="lblValue" runat="server"></asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="panValueEdit" runat="server" Visible="False">
                        <asp:TextBox ID="txtValue" runat="server" CssClass="textTextBox" MaxLength="10"></asp:TextBox>
                    </asp:Panel>
                </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Pedido
                Provisão</td>
            <td class="textProcessFields">
                <asp:Panel ID="pnProvisionRequest" runat="server">
                    <asp:Label ID="Label69" runat="server" Text="1º" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblProvisionRequest1" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label71" runat="server" Text="2º" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblProvisionRequest2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label73" runat="server" Text="3º" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblProvisionRequest3" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label81" runat="server" Text="Reforço" 
                        CssClass="textProcessColumns"></asp:Label>
                    &nbsp;<asp:Label ID="Label75" runat="server" Text="1º" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblProvisionReinforcement1" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label77" runat="server" Text="2º" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblProvisionReinforcement2" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="Label79" runat="server" Text="3º" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:Label ID="lblProvisionReinforcement3" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnProvisionRequestEdit" runat="server" Visible="False">
                    <asp:Label ID="Label62" runat="server" Text="1º"></asp:Label>
                    <asp:TextBox ID="txtProvisionRequest1" runat="server" CssClass="textTextBox" 
                        Width="72px"></asp:TextBox>
    &nbsp;<asp:Label ID="Label63" runat="server" Text="2º"></asp:Label>
                    <asp:TextBox ID="txtProvisionRequest2" runat="server" CssClass="textTextBox" Width="72px"></asp:TextBox>
    &nbsp;<asp:Label ID="Label64" runat="server" Text="3º"></asp:Label>
                    <asp:TextBox ID="txtProvisionRequest3" runat="server" CssClass="textTextBox" Width="72px"></asp:TextBox>
    &nbsp;<asp:Label ID="Label65" runat="server" CssClass="textProcessColumns" Text="Reforço"></asp:Label>
    &nbsp;<asp:Label ID="Label66" runat="server" Text="1º"></asp:Label>
                    <asp:TextBox ID="txtProvisionReinforcement1" runat="server" CssClass="textTextBox" Width="72px"></asp:TextBox>
    &nbsp;<asp:Label ID="Label67" runat="server" Text="2º"></asp:Label>
                    <asp:TextBox ID="txtProvisionReinforcement2" runat="server" CssClass="textTextBox" Width="72px"></asp:TextBox>
    &nbsp;<asp:Label ID="Label68" runat="server" Text="3º"></asp:Label>
                    <asp:TextBox ID="txtProvisionReinforcement3" runat="server" CssClass="textTextBox" Width="72px"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns">
                Valor a Recuperar
            </td>
            <td class="textProcessFields">
                <asp:Panel ID="panValueToRecover" runat="server">
                    <asp:Label ID="lblValueToRecover" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="panValueToRecoverEdit" runat="server" Visible="False">
                    <asp:TextBox ID="txtValueToRecover" runat="server" CssClass="textTextBox"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Despesas AE
            </td>
            <td class="textProcessFields">
                <asp:Panel ID="panExesAe" runat="server">
                    <asp:Label ID="lblExesAe" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="panExesAeEdit" runat="server" Visible="False">
                    <asp:TextBox ID="txtExesAe" runat="server" CssClass="textTextBox"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
             Exequente</td>
            <td class="textProcessFields">
                <asp:Label ID="lblCreditor" runat="server"></asp:Label>
                <asp:Panel ID="panCreditorEdit" runat="server" Visible="False">
                    <asp:DropDownList ID="cmbCreditor" runat="server" AutoPostBack="True" 
                        CssClass="textLabelB" onselectedindexchanged="cmbCreditor_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;<asp:ImageButton ID="imgBtCreditorDelete" runat="server" 
                        ImageUrl="~/images/webapp/icons/filedelete.png" 
                        onclick="imgBtCreditorDelete_Click" ToolTip="Apagar Exequente" />
                    <br />
                    <asp:TextBox ID="txtCreditorName" runat="server" CssClass="textTextBox" Width="150px" MaxLength="100"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="imgBtCreditorEditInfo" runat="server" 
                        ImageUrl="~/images/webapp/icons/edit.png" onclick="imgBtCreditorEditInfo_Click" 
                        ToolTip="Editar Exequente" />
                    <asp:ImageButton ID="imgBtCreditorProcessInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/add.png" 
                        onclick="imgBtCreditorProcessInsert_Click" 
                        ToolTip="Adicionar Exequente ao processo" />
                    <asp:ImageButton ID="imgBtCreditorInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/new.png" onclick="imgBtCreditorInsert_Click" 
                        ToolTip="Inserir Novo Exequente" />
                    <asp:Panel ID="panCreditorEditInfo" runat="server" CssClass="panelEdit" 
                        Visible="False" Width="100%">
                        <asp:Label ID="Label6" runat="server" CssClass="panelEditLabel" Text="Morada"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorAddress" runat="server" CssClass="textTextBox" 
                            Rows="100"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" CssClass="panelEditLabel" Text="Telefone"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorPhone" runat="server" CssClass="textTextBox" 
                            Rows="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblCreditorMPhone" runat="server" CssClass="panelEditLabel" Text="Telemóvel"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorMPhone" runat="server" CssClass="textTextBox" 
                            Rows="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" CssClass="panelEditLabel" Text="Fax"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorFax" runat="server" CssClass="textTextBox" 
                            Rows="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label9" runat="server" CssClass="panelEditLabel" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorEmail" runat="server" CssClass="textTextBox" 
                            Rows="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label52" runat="server" CssClass="panelEditLabel" Text="BI"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorIdentityCard" runat="server" CssClass="textTextBox" 
                            Rows="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label53" runat="server" CssClass="panelEditLabel" 
                            Text="NIF/NIPC"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorNifNipl" runat="server" CssClass="textTextBox" 
                            Rows="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label54" runat="server" CssClass="panelEditLabel" Text="NISS"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorNifs" runat="server" CssClass="textTextBox" 
                            Rows="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label55" runat="server" CssClass="panelEditLabel" 
                            Text="Data Nasc."></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCreditorBornDate" runat="server" CssClass="textTextBox"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="txtCreditorBornDate" ErrorMessage="**" 
                            Operator="DataTypeCheck" SetFocusOnError="True" Type="Date" 
                            ValidationGroup="CreditorSave"></asp:CompareValidator>
                        &nbsp;<asp:ImageButton ID="imgBtCreditorEditSave" runat="server" 
                            ImageUrl="~/images/webapp/icons/save.png" 
                            onclick="imgBtCreditorEditSave_Click" 
                            ToolTip="Gravar dados do exequente" />
                        <asp:ImageButton ID="imgBtCreditorCancel" runat="server" 
                            ImageUrl="~/images/webapp/icons/filedelete.png" 
                            onclick="imgBtCreditorCancel_Click" 
                            ToolTip="Cancelar alteração de daods do Exequente" />
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Mandatário</td>
            <td class="textProcessFields">
                <asp:Label ID="lblRepresentative" runat="server"></asp:Label>
                <asp:Panel ID="panRepresentativeEdit" runat="server" Visible="False">
                    <asp:TextBox ID="txtRepresentativeName" runat="server" CssClass="textTextBox" 
                        MaxLength="100" Width="150px"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="imgBtRepresentativeEditInfo" runat="server" 
                        ImageUrl="~/images/webapp/icons/edit.png" 
                        onclick="imgBtRepresentativeEditInfo_Click" ToolTip="Editar Mandatario" />
                    <asp:ImageButton ID="imgBtRepresentativeProcessInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/add.png" 
                        onclick="imgBtRepresentativeProcessInsert_Click" 
                        ToolTip="Adicionar Mandatario ao processo" />
                    <asp:ImageButton ID="imgBtRepresentativeInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/new.png" 
                        onclick="imgBtRepresentativeInsert_Click" ToolTip="Inserir Novo" />
                    <asp:Panel ID="panRepresentativeEditInfo" runat="server" CssClass="panelEdit" 
                        Visible="False">
                        <asp:Label ID="Label10" runat="server" CssClass="panelEditLabel" Text="Morada"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtRepresentativeAddress" runat="server" 
                            CssClass="textTextBox" MaxLength="100"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label11" runat="server" CssClass="panelEditLabel" 
                            Text="Telefone"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtRepresentativePhone" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label12" runat="server" CssClass="panelEditLabel" Text="Fax"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtRepresentativeFax" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label13" runat="server" CssClass="panelEditLabel" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtRepresentativeEmail" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        &nbsp;<asp:ImageButton ID="imgBtRepresentativeEditSave" runat="server" 
                            ImageUrl="~/images/webapp/icons/save.png" 
                            onclick="imgBtRepresentativeEditSave_Click" 
                            ToolTip="Gravar dados do Mandatário" />
                        <asp:ImageButton ID="imgBtRepresentativeCancel" runat="server" 
                            ImageUrl="~/images/webapp/icons/filedelete.png" 
                            onclick="imgBtRepresentativeCancel_Click" 
                            ToolTip="Cancelar alteração de dados do Mandatário" />
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Executado</td>    
            <td class="textProcessFields">
                <asp:Label ID="lblExecuted" runat="server"></asp:Label>
                <asp:Panel ID="panExecutedEdit" runat="server" Visible="False">
                    <asp:DropDownList ID="cmbExecuted" runat="server" CssClass="textLabelB" 
                        AutoPostBack="True" onselectedindexchanged="cmbExecuted_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;<asp:ImageButton ID="imgBtExecutedDelete" runat="server" 
                        ImageUrl="~/images/webapp/icons/filedelete.png" 
                        onclick="imgBtExecutedDelete_Click" Width="24px" />
                    <br />
                    <asp:TextBox ID="txtExecutedName" runat="server" CssClass="textTextBox" 
                        MaxLength="100" Width="150px"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="imgBtExecutedEdit" runat="server" 
                        ImageUrl="~/images/webapp/icons/edit.png" 
                        onclick="imgBtExecutedEdit_Click" ToolTip="Editar dados Executado " />
                    <asp:ImageButton ID="imgBtExecutedProcessInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/add.png" 
                        onclick="imgBtExecutedProcessInsert_Click" 
                        ToolTip="Adicionar Executado ao Processo" />
                    <asp:ImageButton ID="imgBtExecutedInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/new.png" onclick="imgBtExecutedInsert_Click" 
                        ToolTip="Inserir Novo Executado" />
                    <asp:ImageButton ID="imgBtExecutedExtraAddress" runat="server" 
                        ImageUrl="~/images/webapp/icons/new.png" 
                        onclick="imgBtExecutedExtraAddress_Click" 
                        ToolTip="Adicionar morada do Executado" />
                    <asp:Panel ID="panExecutedEditInfo" runat="server" CssClass="panelEdit" 
                        Visible="False">
                        <asp:Label ID="Label14" runat="server" CssClass="panelEditLabel" Text="Morada"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedAddress" runat="server" CssClass="textTextBox" 
                            MaxLength="100"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label15" runat="server" CssClass="panelEditLabel" 
                            Text="Telefone"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedPhone" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label16" runat="server" CssClass="panelEditLabel" Text="Fax"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedFax" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label17" runat="server" CssClass="panelEditLabel" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedEmail" runat="server" CssClass="textTextBox" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label56" runat="server" CssClass="panelEditLabel" Text="BI"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedIdentityCard" runat="server" CssClass="textTextBox" 
                            MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label57" runat="server" CssClass="panelEditLabel" 
                            Text="NIF/NIPC"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedNifNipl" runat="server" CssClass="textTextBox" 
                            MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label58" runat="server" CssClass="panelEditLabel" Text="NISS"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedNifs" runat="server" CssClass="textTextBox" 
                            MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label59" runat="server" CssClass="panelEditLabel" 
                            Text="Data Nasc."></asp:Label>
                        <br />
                        <asp:TextBox ID="txtExecutedBornDate" runat="server" CssClass="textTextBox"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="txtExecutedBornDate" ErrorMessage="**" 
                            Operator="DataTypeCheck" SetFocusOnError="True" Type="Date" 
                            ValueToCompare="ExecutedSave"></asp:CompareValidator>
                        &nbsp;<asp:ImageButton ID="imgBtExecutedEditSave" runat="server" 
                            ImageUrl="~/images/webapp/icons/save.png" 
                            onclick="imgBtExecutedEditSave_Click" 
                            ToolTip="Gravar dados do Executado" />
                        <asp:ImageButton ID="imgBtExecutedCancel" runat="server" 
                            ImageUrl="~/images/webapp/icons/filedelete.png" 
                            onclick="imgBtExecutedCancel_Click" 
                            ToolTip="Cancelar alteração dados Executado" />
                    </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                PAGAMENTOS PROCESSO</td>
        </tr>
        <tr>
            <td colspan="2" class="textProcessFields">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                OBSERVAÇÕES PROCESSO
                <asp:ImageButton ID="imgBtEditProcessObservation" runat="server" ImageUrl="~/images/webapp/icons/edit.png"
                    OnClick="imgBtEditProcessObservation_Click" ToolTip="Editar observação processo" />
                <asp:ImageButton ID="imgBtSaveProcessObservation" runat="server" ImageUrl="~/images/webapp/icons/save.png"
                    OnClick="imgBtSaveProcessObservation_Click" Visible="False" ToolTip="Gravar observação do pocesso" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="textProcessFields">
                <asp:Label ID="lblObservation" runat="server"></asp:Label>
                <asp:Panel ID="panObservationEdit" runat="server">
                    <asp:TextBox ID="txtObservation" runat="server" CssClass="textTextBox" onkeypress='return (this.value.length <= 4000);'
                        Height="50px" TextMode="MultiLine" Visible="False" Width="870px"></asp:TextBox>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                INFORMAÇÃO PROCESSO
            <asp:ImageButton ID="imgBtSaveDetails" runat="server" 
    ImageUrl="~/images/webapp/icons/save.png" onclick="imgBtSaveDetails_Click" 
                    ToolTip="Gravar Alteracoes" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
<%--                <uc3:wucProcessDetails ID="wucProcessDetails1" runat="server" />--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="margin: 0 0 10px 0;">
                            <div class="divErro">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </div>
                        </div>

                        <div class="textProcessColumns" style="text-align: left; width: 100%;">
                            <div style="float: left; margin: 0 10px 15px 0;">
                                Acordo Pagamento<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbPaymentAgreement" runat="server"
                                    Width="100px">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                Extinção Processo<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbProcessExtinction"
                                    runat="server" Width="400px">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                Código Extinção<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbExtinctionCode" runat="server"
                                    Width="100px">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                Diligências no Local<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbArrangementsInPlace" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <img alt="spacer" src="../../images/spacer.png" height="5" width="100%" />
                        <div class="textProcessColumns" style="text-align: left; width: 100%; margin: 0 0 10px 0;">
                            <div style="float: left; margin: 0 10px 10px 0;">
                                Em Penhora<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbInAttachment" runat="server" Width="200px">
                                    <asp:ListItem Text="-" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Não" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                Estado Processo<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbProcessState" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                Consulta Base de Dados<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbDBInfo" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 20px 0;">
                                Certidão Incobrabilidade<br />
                                <asp:DropDownList CssClass="textLabelB" ID="cmbUncollectabilityCertificate" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="text-align: left;">
                            <div style="float: left; margin: 0 10px 15px 0;">
                                <asp:Label ID="Label1" runat="server" Text="Provisão" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtProvision" runat="server" CssClass="textTextBox" MaxLength="10"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                <asp:Label ID="Label19" runat="server" Text="Data Recepção Provisão" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtProvisionReceptionDate" runat="server"
                                    CssClass="textTextBox" MaxLength="10" ToolTip="dd-mm-aaaa"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                <asp:Label ID="Label20" runat="server" Text="Aguarda Pagamento Factura" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtPendingInvoicePayment" runat="server" CssClass="textTextBox" MaxLength="10"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                <asp:Label ID="Label21" runat="server" Text="Data Pagamento Factura" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtPendingInvoicePaymentDate" runat="server"
                                    CssClass="textTextBox" MaxLength="10" ToolTip="dd-mm-aaaa"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 15px 0;">
                                <asp:Label ID="Label22" runat="server" Text="Localidade da Diligência" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtDiligenceLocation" runat="server" CssClass="textTextBox" MaxLength="50"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 5px 0;">
                                <asp:Label ID="Label23" runat="server" Text="Fase Judicial" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:DropDownList ID="cmbJudicialPhase" runat="server" CssClass="textLabelB">
                                    <asp:ListItem Text="-" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Declarativa" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Desistência" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Executiva" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 0 10px 5px 0;">
                                <asp:Label ID="Label90" runat="server" Text="Ref. Processo Exequente" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox runat="server" ID="txtCreditorReference" CssClass="textTextBox"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 5px 0;">
                                <asp:Label ID="Label91" runat="server" Text="Data Aceitação" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtAcceptDate" runat="server" CssClass="textTextBox"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 10px 0;">
                                <asp:Label ID="Label92" runat="server" Text="Data Rec. Duplicados" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtDuplicatesReceipt" runat="server" CssClass="textTextBox"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 10px 0;">
                                <asp:Label ID="Label94" runat="server" Text="Alerta Num.Dias" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtAlert" runat="server" CssClass="textTextBox" Width="70"
                                    ToolTip="0 para desactivar o alerta"></asp:TextBox>
                            </div>
                            <div style="float: left; margin: 0 10px 5px 0;">
                                <asp:Label ID="Label93" runat="server" Text="Informações do Juiz" CssClass="textProcessColumns"></asp:Label><br />
                                <asp:TextBox ID="txtJudgeObservation" Width="900px" MaxLength="4000"
                                    runat="server" CssClass="textTextBox" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="clear: both;"></div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnDelegate" runat="server">
                            <div style="padding: 10px 0 0 0; text-align: left;">
                                <div style="margin: 0 0 10px 0;">
                                    <asp:Label ID="Label24" runat="server" Text="Delegado"
                                        CssClass="textProcessColumns"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="cmbDelegate" runat="server" CssClass="textLabelB"></asp:DropDownList>
                                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" MaxLength="4000"
                                        Width="500px" CssClass="textTextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="txtObservation" ErrorMessage="*" SetFocusOnError="True"
                                        ValidationGroup="AddSave"></asp:RequiredFieldValidator>
                                    <asp:ImageButton ID="imgBtAdd"
                                        runat="server" ImageUrl="~/images/webapp/icons/add.png"
                                        ToolTip="Adicionar Delegado e Informação" OnClick="imgBtAdd_Click"
                                        ValidationGroup="AddSave" />
                                    <asp:ImageButton ID="imgBtSave"
                                        runat="server" ImageUrl="~/images/webapp/icons/save.png"
                                        ToolTip="Gravar Alteração" Visible="False" OnClick="imgBtSave_Click"
                                        ValidationGroup="AddSave" />
                                </div>

                                <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None"
                                    OnSelectedIndexChanged="gvResult_SelectedIndexChanged"
                                    CssClass="textLabel" OnRowCommand="gvResult_RowCommand"
                                    OnRowCreated="gvResult_RowCreated">
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


            </td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                FICHEIROS PROCESSO
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:wucProcessFiles ID="wucProcessFiles1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                DILIGÊNCIAS PRÉVIAS
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Buscas</td>
            <td class="textProcessFields">
                        <asp:DropDownList ID="cmbSearchExecuted" runat="server" CssClass="textLabelB">
                    </asp:DropDownList>
&nbsp;<asp:Label ID="Label42" runat="server" CssClass="textLabel" Text="Tipo"></asp:Label>
            <asp:TextBox ID="txtSearchName" runat="server" CssClass="textTextBox"></asp:TextBox>
                &nbsp;<asp:Label ID="Label43" runat="server" CssClass="textLabel" Text="Data"></asp:Label>
                    <asp:TextBox ID="txtSearchDate" runat="server" CssClass="textTextBox"></asp:TextBox>
                &nbsp;<asp:Label ID="Label44" runat="server" CssClass="textLabel" Text="Observação"></asp:Label>
                    <asp:TextBox ID="txtSearchObservation" runat="server" CssClass="textTextBox"></asp:TextBox>
&nbsp;<asp:ImageButton ID="imgBtSearchInsert" runat="server" 
                            ImageUrl="~/images/webapp/icons/add.png" 
                            onclick="imgBtSearchInsert_Click" />
                        <br />
                        <asp:GridView ID="gvResultSearch" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" CellSpacing="1" ForeColor="#333333" GridLines="None" 
                            Width="100%" onrowcommand="gvResultSearch_RowCommand" 
                            onrowcreated="gvResultSearch_RowCreated" 
                            onrowdatabound="gvResultSearch_RowDataBound">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField HeaderText="Executado" DataField="ExecutedName" />
                                <asp:BoundField HeaderText="Tipo" DataField="SearchName"/>
                                <asp:BoundField HeaderText="Data" DataField="Date" />
                                <asp:BoundField HeaderText="Observação" DataField="Obs" />
                                <asp:TemplateField HeaderText="Confirmado?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtCheck" runat="server" CommandName="check" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtDelete" ImageUrl="~/images/webapp/icons/filedelete.png" runat="server" CommandName="delete" OnClientClick="return YesNo();" />
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
            </td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                DILIGÊNCIAS REALIZADAS
            </td>
        </tr>
        <tr>
            <td  class="textProcessColumns" valign="top">
                Entidade Patronal</td>
            <td class="textProcessFields">
                <asp:Panel ID="panEmployer" runat="server">
                    <asp:DropDownList ID="cmbEmployerExecuted" runat="server" CssClass="textLabelB">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label60" runat="server" Text="Entidade Patronal"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEmployerName" runat="server" CssClass="textTextBox"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="imgBtEmployerEdit" runat="server" 
                        ImageUrl="~/images/webapp/icons/edit.png" 
                        onclick="imgBtEmployerEdit_Click" ToolTip="Editar Entidade Patronal" />
                    <asp:ImageButton ID="imgBtEmployerInsert" runat="server" 
                        ImageUrl="~/images/webapp/icons/add.png" 
                        onclick="imgBtEmployerInsert_Click" 
                        ToolTip="Adicionar Entidade Patronal" />
                    <asp:Panel ID="panEmployerEdit" runat="server" CssClass="panelEdit" 
                        Visible="False">
                        <asp:Label ID="Label48" runat="server" CssClass="textLabelB" Text="Morada"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmployerAddress" runat="server" CssClass="textTextBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label49" runat="server" CssClass="textLabelB" Text="Telefone"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmployerPhone" runat="server" CssClass="textTextBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label50" runat="server" CssClass="textLabelB" Text="Fax"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmployerFax" runat="server" CssClass="textTextBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label51" runat="server" CssClass="textLabelB" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmployerEmail" runat="server" CssClass="textTextBox"></asp:TextBox>
                        &nbsp;<asp:ImageButton ID="imgBtEmployerSave" runat="server" 
                            ImageUrl="~/images/webapp/icons/save.png" onclick="imgBtEmployerSave_Click" 
                            ToolTip="Gravar alteração de dados" />
                        <asp:ImageButton ID="imgBtEmployerCancel" runat="server" 
                            ImageUrl="~/images/webapp/icons/filedelete.png" 
                            onclick="imgBtEmployerCancel_Click" 
                            ToolTip="Cancelar alteração de dados" />
                    </asp:Panel>
                </asp:Panel>
                <asp:Label ID="lblEmployer" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Penhora<td class="textProcessFields">
                <asp:DropDownList ID="cmbAttachment" runat="server" CssClass="textLabelB">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label61" runat="server" Text="Penhora"></asp:Label>
&nbsp;<asp:TextBox ID="txtAttachment" runat="server" CssClass="textTextBox" 
                    Width="140px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="imgBtAttachmentAdd" runat="server" 
                    ImageUrl="~/images/webapp/icons/add.png" 
                    onclick="imgBtAttachmentAdd_Click" ToolTip="Adicionar Penhora Processo" />
                <asp:ImageButton ID="imgBtAttachmentInsert" runat="server" 
                    ImageUrl="~/images/webapp/icons/new.png" 
                    onclick="imgBtAttachmentInsert_Click" ToolTip="Inserir Nova Penhora" />
                <br />
                <asp:GridView ID="gvResultAttachment" runat="server" CellPadding="4" CellSpacing="1" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" 
                    onrowcommand="gvResultAttachment_RowCommand" 
                    onrowcreated="gvResultAttachment_RowCreated" 
                    onrowdatabound="gvResultAttachment_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Penhora" DataField="AttachmentName" />
                        <asp:BoundField HeaderText="Executado" DataField="ExecutedName" />
                        <asp:TemplateField HeaderText="Confirmado?">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtCheck" runat="server" CommandName="check" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtDelete" ImageUrl="~/images/webapp/icons/filedelete.png" runat="server" CommandName="delete" OnClientClick="return YesNo();" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="divContentMix" colspan="2">
                INFORMAÇÕES MANDATÁRIO
            </td>
        </tr>
        <tr>
            <td colspan="2" class="textProcessFields">
            <asp:Panel ID="pRepresentativeInformation" runat="server" Visible="false">
<%--                <uc2:wucRepresentativeInformation ID="wucRepresentativeInformation1" runat="server" />--%>
                        <asp:TextBox ID="txtRepresentativeInformation" runat="server" CssClass="textTextBox"
            Width="500px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
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

            </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                CLIENTE
                </td>
        </tr>
        <tr>
            <td colspan="2" class="textProcessFields">
                <div id="divClient"></div>
                Cliente <input type="text" id="clientName" /> <div style="display:inline;" onclick="AddProcessClient()" ><img src="../../images/webapp/icons/add.png" alt="" /></div>
                <table id="tableClient">
                    <thead>
                        <tr>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                ALTERAÇÃO PROCESSO
                </td>
        </tr>
        <tr>
            <td colspan="2" class="textProcessFields">
                <asp:Label ID="lblAlterInfo" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <script type="text/javascript">

        function GetIRS(_processId) {
            $.ajax({
                type: "GET", url: "services/ProcessEService.svc/GetIRS", cache: false, data: {
                    'processId': _processId,
                }
            }).done(function (msg) {
                if (msg.d != '01-01-1970') {
                    $('#txtIRS').val(msg.d);
                }
                else {
                    $('#txtIRS').val('');
                }
            });
        }
        function GetIRS(_processId) {
            $.ajax({
                type: "GET", url: "services/ProcessEService.svc/GetIRS", cache: false, data: {
                    'processId': _processId,
                }
            }).done(function (msg) {
                if (msg.d != '01-01-1970') {
                    $('#txtIRS').val(msg.d);
                }
                else {
                    $('#txtIRS').val('');
                }
            });
        }

        function SetIRS() {
            $.ajax({
                type: "GET", url: "services/ProcessEService.svc/SetIRS", cache: false, data: {
                    'processId': getParameterByName('pr'),
                    'newDate': $('#txtIRS').val()
                }
            }).done(function (msg) {
                if (msg.d == 'ok') {
                    alert('alterado com sucesso!');
                }
            });
        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.search);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        $(document).ready(function () {
            GetIRS(getParameterByName('pr'));
            GetProcessClient(getParameterByName('pr'));
        });

        function GetProcessClient(_processId) {
            $.ajax({
                type: "GET", url: "services/ProcessEService.svc/GetProcessClient", cache: false, data: {
                    'processId': _processId,
                }
            }).done(function (msg) {
                $.each(msg.d, function (i, item) {
                    $('<tr>').html("<td>" + item.ClientName + "</td><td><input type='button' value='apagar' onclick=\"DelProcessClient('" + item.ClientName + "'," + item.ProcessId + ")\" />" + "</td>").appendTo('#tableClient');
                });
            });
        }

        function AddProcessClient() {
            if ($("#clientName").val().length > 0) {
                $.ajax({
                    type: "GET", url: "services/ProcessEService.svc/AddProcessClient", cache: false, data: {
                        'clientName': $("#clientName").val(),
                        'processId': getParameterByName('pr')
                    }
                }).done(function (msg) {
                    $("#tableClient > tbody").html("");
                    $("#clientName").val('');
                    GetProcessClient(getParameterByName('pr'));
                });
            }
        }

        function DelProcessClient(_clientName, _processId) {
            $.ajax({
                type: "GET", url: "services/ProcessEService.svc/DelProcessClient", cache: false, data: {
                    'clientName': _clientName,
                    'processId': _processId
                }
            }).done(function (msg) {
                $("#tableClient > tbody").html("");
                GetProcessClient(getParameterByName('pr'));
            });
        }
    </script>
</asp:Content>
