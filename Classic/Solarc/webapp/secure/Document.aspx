<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.Document" Codebehind="Document.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdateProgress ID="uProgress" runat="server" DisplayAfter="100">
        <ProgressTemplate>
            <div class="update">
                <img alt="Loading" src="../../images/webapp/loading.gif" />&nbsp;A carregar...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="uPanelDocument" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <div class="divErro">
                <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
            </div>
            <div>
                <asp:Label runat="server" ID="lblDocument" CssClass="textLabel">Minutas</asp:Label>
                &nbsp;<asp:DropDownList runat="server" ID="cmbDocument" CssClass="textTextBox">
                </asp:DropDownList>
                &nbsp;<asp:LinkButton runat="server" ID="lkbGenerate" 
                    OnClick="lkbGenerate_Click" CssClass="textLink">Gerar Documento</asp:LinkButton>
                &nbsp;<asp:LinkButton runat="server" ID="lkbNew" OnClick="lkbNew_Click" 
                    CssClass="textLink">Novo Documento</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="lkbEdit" runat="server" OnClick="lkbEdit_Click" 
                    CssClass="textLink">Editar</asp:LinkButton>
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/webapp/secure/minutas.pdf"
                    Target="_blank" CssClass="textLink">Referencias Campos Processo</asp:HyperLink>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upEdit" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnEdit" Visible="false">
                        <asp:Panel runat="server" ID="pnDocumentName" Visible="false">
                            <asp:Label runat="server" ID="lblName" CssClass="textLabel">Nome Documento</asp:Label>&nbsp;<asp:TextBox 
                                runat="server" ID="txtDocumentName" CssClass="textTextBox"></asp:TextBox>
                        </asp:Panel>
                        <div>
                            <cc1:Editor ID="htmlEditor" runat="server" OnContentChanged="lkbSave_Click" Height="300px" Width="100%" AutoFocus="true" />
                            <br />
                            <asp:LinkButton ID="lkbAddDocument" runat="server" 
                                onclick="lkbAddDocument_Click" Visible="False" CssClass="textLink">Inserir</asp:LinkButton>
                            <asp:LinkButton ID="lkbSave" runat="server" onclick="lkbSave_Click" 
                                Visible="False" CssClass="textLink">Gravar</asp:LinkButton>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lkbEdit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lkbNew" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
    <asp:UpdatePanel ID="upGenerate" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnGenerate" Visible="false">
                <div style="padding:5px;">
                    <div>
                        <asp:Label runat="server" ID="lblInternalCode" CssClass="textLabel">Código Interno</asp:Label>
                        <asp:TextBox
                            runat="server" ID="txtInternalCode" CssClass="textTextBox"></asp:TextBox></div>
                    <div>
                        <asp:Label runat="server" ID="lblProcessNumber" CssClass="textLabel">Numero Processo</asp:Label>
                        <asp:TextBox
                            runat="server" ID="txtProcessNumber" CssClass="textTextBox"></asp:TextBox></div>
                    <div>
                        <asp:LinkButton runat="server" ID="lkbSearch" OnClick="lkbSearch_Click" 
                            CssClass="textLink">Pesquisar</asp:LinkButton>&nbsp;<asp:DropDownList
                            runat="server" ID="cmbResult" CssClass="textTextBox">
                        </asp:DropDownList>
                        &nbsp;<asp:LinkButton runat="server" ID="lkbOk" OnClick="lkbOk_Click" 
                            CssClass="textLink">OK</asp:LinkButton></div>
                </div>
                <asp:Panel runat="server" ID="pnExecutedCreditor" Visible="false">
                    <div style="padding:5px;">
                    <asp:Label ID="Label2" runat="server" Text="Solicitador(a)" 
                        CssClass="textLabel"></asp:Label>
                    &nbsp;<asp:DropDownList ID="cmbSolicitor" runat="server" CssClass="textTextBox">
                    </asp:DropDownList>
                    <br />
                    <asp:Label runat="server" ID="lblCreditor" CssClass="textLabel">Exequente</asp:Label>&nbsp;<asp:DropDownList
                        runat="server" ID="cmbCreditor" CssClass="textTextBox">
                    </asp:DropDownList>
                    <br />
                    <asp:Label runat="server" ID="lblExecuted" CssClass="textLabel">Executado</asp:Label>&nbsp;<asp:DropDownList
                        runat="server" ID="cmbExecuted" CssClass="textTextBox">
                    </asp:DropDownList>
                    <br />
                    <asp:CheckBox ID="ckbBold" runat="server" Checked="True" 
                        Text="Campos do processo a negrito?" CssClass="textLabel" />
                    <br />
                    <asp:CheckBox ID="ckbHeader" runat="server" Checked="True" 
                        Text="Adicionar cabeçalho com identificação processo ?" CssClass="textLabel" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Destinatário:" CssClass="textLabel"></asp:Label>
                    &nbsp;<asp:RadioButtonList ID="rblToLetter" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" CssClass="textLabel">
                        <asp:ListItem Text="Executado"></asp:ListItem>
                        <asp:ListItem Text="Exequente"></asp:ListItem>
                        <asp:ListItem Text="Mandatário" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:LinkButton runat="server" ID="lkbExecutedCreditor" 
                        OnClick="lkbExecutedCreditor_Click" CssClass="textLink">Ok</asp:LinkButton>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnTexto" Visible="false">
                    <asp:TextBox ID="txtText" runat="server" Height="173px" TextMode="MultiLine" 
                        Width="700px" CssClass="textTextBox"></asp:TextBox>
                    <br />
                    <asp:LinkButton ID="lkbCreatePDF" runat="server" OnClick="lkbCreatePDF_Click">Clique aqui para gerar o PDF</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
            <asp:HyperLink ID="hlPdf" runat="server">[hlPdf]</asp:HyperLink>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lkbGenerate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:LinkButton runat="server" ID="lkbDownloadFile" Visible="false">Clique para fazer download do ficheiro WORD gerado</asp:LinkButton>
</asp:Content>



