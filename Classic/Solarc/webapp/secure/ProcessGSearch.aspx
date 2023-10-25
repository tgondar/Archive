<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" CodeBehind="ProcessGSearch.aspx.cs" Inherits="Solarc.webapp.secure.ProcessGSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContentTitle">
        <div class="divContent">
            1. Opções de Pesquisa</div>
    </div>
    <div class="divContentFields">
        <div  class="ui-widget" style="text-align:left;">
            <label for="txtEntity">
                Cliente:
            </label>
            <input id="txtEntity" />
                <label for="txtCode">
                Referência Interna:
            </label>
            <input id="txtCode" />
            <label for="txtReference">
                Referencia Cliente:
            </label>
            <input id="txtReference" />
            <input type="button" value="pesquisar" onclick="searchProcessG()" />
            <input type="button" value="novo" onclick="ViewForm()" />
        </div>
    </div>
    <div class="divContentTitle">
        <div class="divContent">
            2. Resultados</div>
    </div>
    <div class="divContentFields">
        <div id="result"></div>
    </div>

    <style>
    .ui-autocomplete { max-height: 200px; overflow-y: auto; overflow-x: hidden; padding-right: 20px; }
    * html .ui-autocomplete { height: 100px; }
</style>
    <script language="javascript" type="text/javascript">
        function searchProcessG() {
            $.ajax({
                type: "GET", url: "services/ProcessGService.svc/GetProcesses", cache: false, data: { entity: $('#txtEntity').val(), code: $('#txtCode').val(), reference: $('#txtReference').val() }
            }).done(function (msg) {
                $('#result').html(msg.d);
            });
        }

        function ViewForm() {
            $("#newProcessForm").css({
                'display': 'block',
                'position': 'fixed',
                'top': '0px',
                'left': '0px',
                'padding': '0px',
                'width': '100%',
                'color': '#333',
                'height': '100%',
                'background-image': 'url("../../images/specpopupbg.png")',
                'z-index': '100'
            });
            $("#newProcessFormContent").css({
                'position': 'absolute',
                'padding': '10px',
                'width': '400px',
                'left': '50%',
                'margin-left': '-200px',
                'top': '30px',
                'font-weight': 'bold',
                'z-index': '101',
                'background': '#f1f1f1',
                'border': '1px solid #666666'
            });
        }

        function CloseForm() {
            $('#newProcessForm').css('display', 'none');
        }

        function AddProcessG() {
            $.ajax({
                type: "GET", url: "services/ProcessGService.svc/AddProcess",
                data: {
                    entity: $('#txtEntity2').val(),
                    code: $('#txtCode2').val(),
                    reference: $('#txtReference2').val(),
                    observation: $('#txtObservation').val(),
                    localization: $('#txtLocalization').val(),
                    dateAlert: $('#txtDateAlert').val()
                }
            }).done(function (msg) {
                alert('Processo inserido com sucesso -> ' + msg.d);
                $('#txtEntity2').html("");
                $('#txtCode2').html("");
                $('#txtReference2').html("");
                $('#txtObservation').html("");
                $('#txtLocalization').html("");

                if (msg.d == "ok") {
                    CloseForm();
                }
                searchProcessG();
            });
        }

        $(document).ready(function () {
            searchProcessG();
        });

        $(function () {
            $("#txtEntity").autocomplete({
                source: function (request, response) {
                    $.getJSON('services/EntityService.svc/GetEntities', request, function (data) {
                        response(data.d);
                    });
                }
            });
            $("#txtEntity2").autocomplete({
                source: function (request, response) {
                    $.getJSON('services/EntityService.svc/GetEntities', request, function (data) {
                        response(data.d);
                    });
                }
            });
        });

        function DeleteProcess(procGId) {
            if (YesNo() == true) {
                $.ajax({
                    type: "GET", url: "services/ProcessGService.svc/DeleteProcess", cache: false, data: {
                        processGId: procGId
                    }
                }).done(function (msg) {
                    if (msg.d == "ok") {
                        searchProcessG();
                    }
                    else {
                        alert(msg.d);
                    }
                });
            }
        }

    </script>

    <div id="newProcessForm" style="display:none;">
        <div id="newProcessFormContent">
            <h2>
                Novo Processo</h2>
            <label for="txtEntity2">
                Cliente
            </label><br />
            <input id="txtEntity2" />
            <img id="imgNewEntity" onclick="ViewFormEntity()" alt="" src="../../images/webapp/icons/add.png" />
            <br />
            <label for="txtDateAlert">
                Data Alerta
            </label><br />
            <input id="txtDateAlert" />
            <br />
            <label for="txtCode2">
                Ref. Interna
            </label><br />
            <input id="txtCode2" />
            <br />
            <label for="txtReference2">
                Ref. Cliente
            </label><br />
            <input id="txtReference2" />
            <br />
            <label for="txtObservation">
                Observação
            </label><br />
            <input id="txtObservation" />
            <br />
            <label for="txtLocalization">
                Localização
            </label><br />
            <input id="txtLocalization" />
            <br /><br /><br />
            <input type="button" value="Adicionar" onclick="AddProcessG()" />    
            <input type="button" value="cancelar" onclick="CloseForm()" />
        </div>
    </div>
    <!--#include virtual="scripts/entity.htm" -->
</asp:Content>
