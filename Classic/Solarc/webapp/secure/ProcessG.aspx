<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" CodeBehind="ProcessG.aspx.cs" Inherits="Solarc.webapp.secure.ProcessG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
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

    function FillProcess() {
        var pgid = getParameterByName('pgid');
        $.ajax({
            type: "GET", url: "services/ProcessGService.svc/GetProcess", cache: false, data: { processGId: pgid }
        }).done(function (msg) {
            if (msg.d != "") {
                $('#lblCode').html(msg.d.Code);
                $('#lblReference').html(msg.d.Reference);
                $('#lblEntity').html(msg.d.EntityName);
                $('#lblObservation').html(msg.d.Observation);
                $('#lblDateAlert').html(msg.d.DateAlertString);
                $('#lblLocalization').html(msg.d.Localization);
                $('#lblAlterUser').html(msg.d.AlterDateString + '<br />' + msg.d.AlterUser);
                $('#loadingDiv').css('display', 'none');

                GetPayments();
                GetInformation();
            }
        });
    }
    function GetPayments() {
        var pgid = getParameterByName('pgid');
        $.ajax({ type: "GET", url: "services/ProcessGService.svc/GetPayment",cache:false, data: { processgId: pgid }
        }).done(function (msg) {
            if (msg.d != "error") {
                $('#payments').html(msg.d);
                $('#loadingDiv').css('display', 'none');
            }
        });    
    }
    function AddPayment() {
        $('#loadingDiv').css('display', 'block');
       var pgid = getParameterByName('pgid');
        $.ajax({
            type: "GET", url: "services/ProcessGService.svc/AddPayment",cache:false, data: {
                processGId: pgid,
                designation: $('#txtDesignation').val(),
                value: $('#txtValue').val().replace(",", "."),
                income: $('input:radio[name=income]:checked').val(),
                paydate: $('#txtPayDate').val()
            }
        }).done(function (msg) {
            if (msg.d == "ok") {
                GetPayments();
            }
        });
    }

    function DeleteInformation(_informationId) {
        if (YesNo()==true) {
            $('#loadingDiv').css('display', 'block');
            var pgid = getParameterByName('pgid');
            $.ajax({
                type: "GET", url: "services/ProcessGService.svc/DeleteInformation", cache: false, data: {
                    processGId: pgid
                , informationId: _informationId
                }
            }).done(function (msg) {
                if (msg.d == "ok") {
                    GetInformation();
                }
            });
        }
    }

    function DeletePayment(processGId, _paymentId) {
        if (YesNo()==true) {
            $('#loadingDiv').css('display', 'block');
            $.ajax({
                type: "GET", url: "services/ProcessGService.svc/DeletePayment", cache: false, data: {
                    processGId: processGId,
                    paymentId: _paymentId
                }
            }).done(function (msg) {
                if (msg.d == "ok") {
                    GetPayments();
                }
            });
        }
    }

    function GetInformation() {
        var pgid = getParameterByName('pgid');
        $.ajax({ type: "GET", url: "services/ProcessGService.svc/GetInformation",cache:false, data: { processgId: pgid }
        }).done(function (msg) {
            if (msg.d != "error") {
                $('#lblInformation').html(msg.d);
            }
        });    
    }

    function AddInformation() {
        $('#loadingDiv').css('display', 'block');
        var pgid = getParameterByName('pgid');
        $.ajax({ type: "GET", url: "services/ProcessGService.svc/AddInformation",cache:false, data: { processGId: pgid
            , information: $('#txtInformation').val()
        }
        }).done(function (msg) {
            if (msg.d == "ok") {
                GetInformation();
            }
        });
    }

    function AddEntity() {
        $.getScript("scripts/entity.js", function () {
            teste();
        });
    }

    function editField(fieldName) {
        $('#txt' + fieldName).val($('#lbl' + fieldName).html());
        $('#txt' + fieldName).css('display', 'inline');
        $('#lbl' + fieldName).css('display', 'none');
        $('#imgEdit' + fieldName).css('display', 'none');
        $('#imgSave' + fieldName).css('display', 'inline');
    }

    function saveField(fieldName) {
        var pgid = getParameterByName('pgid');
        $.ajax({ type: "GET", url: "services/ProcessGService.svc/SaveProcess",cache:false, data: { processGId: pgid
            , entity: $('#txtEntity').val()
            , code: $('#txtCode').val()
            , reference: $('#txtReference').val()
            , observation: $('#txtObservation').val()
            , localization: $('#txtLocalization').val()
            , dateAlert: $('#txtDateAlert').val()
        }
        }).done(function (msg) {
            if (msg.d == "ok") {
                $('#txt' + fieldName).css('display', 'none');
                $('#lbl' + fieldName).css('display', 'inline');
                $('#imgEdit' + fieldName).css('display', 'inline');
                $('#imgSave' + fieldName).css('display', 'none');
                $('#lbl' + fieldName).html($('#txt' + fieldName).val());
                $('#txt' + fieldName).html("");
            }
        });
    }

    $(function () {
        $("#txtEntity").autocomplete({
            source: function (request, response) {
                $.getJSON('services/EntityService.svc/GetEntities', request, function (data) {
                    response(data.d);
                });
            }
        });
    });

    $(document).ready(function () {
        FillProcess();

        $('#txtCode').css('display', 'none');
        $('#imgSaveCode').css('display', 'none');
        $('#txtReference').css('display', 'none');
        $('#imgSaveReference').css('display', 'none');
        $('#txtEntity').css('display', 'none');
        $('#imgSaveEntity').css('display', 'none');
        $('#txtObservation').css('display', 'none');
        $('#imgSaveObservation').css('display', 'none');
        $('#txtLocalization').css('display', 'none');
        $('#imgSaveLocalization').css('display', 'none');
        $('#txtDateAlert').css('display', 'none');
        $('#imgSaveDateAlert').css('display', 'none');
    });
    </script>
    <table class="BackProcess" align="center" border="0" cellpadding="5" cellspacing="10"
        width="900px">
        <tr>
            <td colspan="2" class="procNum">
                Processo
                <div id="lblCode" style="display:inline;" ></div>
                <img id="imgEditCode" onclick="editField('Code')" alt="" src="../../images/webapp/icons/edit.png" />
                <input id="txtCode" />
                <img id="imgSaveCode" onclick="saveField('Code')" alt="" src="../../images/webapp/icons/save.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                IDENTIFICAÇÃO DO PROCESSO
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top" width="250">
                Referencia
                Cliente</td>
            <td class="textProcessFields">
                <div id="lblReference" style="display:inline;"></div>
                <img id="imgEditReference" onclick="editField('Reference')" alt="" src="../../images/webapp/icons/edit.png" />
                <input id="txtReference" />
                <img id="imgSaveReference" onclick="saveField('Reference')" alt="" src="../../images/webapp/icons/save.png" />
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Cliente
            </td>
            <td class="textProcessFields">
                <div id="lblEntity" style="display:inline;"></div>
                <img id="imgEditEntity" onclick="editField('Entity')" alt="" src="../../images/webapp/icons/edit.png" />
                <input id="txtEntity" />
                <img id="imgSaveEntity" onclick="saveField('Entity')" alt="" src="../../images/webapp/icons/save.png" />
                <img id="imgNewEntity" onclick="ViewFormEntity()" alt="" src="../../images/webapp/icons/add.png" />
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Observação
            </td>
            <td class="textProcessFields">
                <div id="lblObservation" style="display:inline;"></div>
                <img id="imgEditObservation" onclick="editField('Observation')" alt="" src="../../images/webapp/icons/edit.png" />
                <textarea id="txtObservation" rows="3" cols="50">
                </textarea>
                <img id="imgSaveObservation" onclick="saveField('Observation')" alt="" src="../../images/webapp/icons/save.png" />
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Localizacao
            </td>
            <td class="textProcessFields">
                <div id="lblLocalization" style="display:inline;"></div>
                <img id="imgEditLocalization" onclick="editField('Localization')" alt="" src="../../images/webapp/icons/edit.png" />
                <input id="txtLocalization" />
                <img id="imgSaveLocalization" onclick="saveField('Localization')" alt="" src="../../images/webapp/icons/save.png" />
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Data Alerta
            </td>
            <td class="textProcessFields">
                <div id="lblDateAlert" style="display:inline;"></div>
                <img id="imgEditDateAlert" onclick="editField('DateAlert')" alt="" src="../../images/webapp/icons/edit.png" />
                <input id="txtDateAlert" />
                <img id="imgSaveDateAlert" onclick="saveField('DateAlert')" alt="" src="../../images/webapp/icons/save.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                PAGAMENTO(S) DO PROCESSO
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Novo Pagamento
            </td>
            <td class="textProcessFields">
                <div style="float:left; margin:0 10px 0 0;">
                    <input type="radio" name="income" value="true" checked="checked" /><span style="color:green;">Entrada</span><br />
                    <input type="radio" name="income" value="false" /><span style="color:red;">Saída</span>
                </div>
                <div style="float:left; margin:0 5px 0 0;">
                    Valor<br /><input id="txtValue" style=" width:80px;" />
                </div>
                <div style="float:left; margin:0 5px 0 0;">
                    Data<br /><input id="txtPayDate" style=" width:80px;" />
                </div>
                <div style="float:left;">
                    Designação<br />
                    <input id="txtDesignation" style=" width:200px;" />
                    <input id="btAddPayment" type="button" value="Adicionar" onclick="AddPayment()" />
                </div>
                <div style="clear:both; padding:10px 0 10px 0;">
                    <div id="payments"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                INFORMAÇÃO DO PROCESSO
            </td>
        </tr>
        <tr>
            <td colspan="2" class="lblAlterUser">
                <input id="txtInformation" style=" width:500px;" />
                <input id="btAddInformation" type="button" value="Adicionar" onclick="AddInformation()" /><br />
                <div id="lblInformation"></div>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="divContentMix">
                ALTERAÇÃO PROCESSO
            </td>
        </tr>
        <tr>
            <td class="textProcessColumns" valign="top">
                Alteração
            </td>
            <td class="lblAlterUser">
                <div id="lblAlterUser"></div>
            </td>
        </tr>
    </table>
    <!--#include virtual="scripts/entity.htm" -->
</asp:Content>
