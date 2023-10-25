<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" Inherits="Solarc.webapp.secure.Default" Codebehind="Default.aspx.cs" %>
<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>
<%@ Register src="wucUserSettings.ascx" tagname="wucUserSettings" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register src="wucProcessAlert.ascx" tagname="wucProcessAlert" tagprefix="uc5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../includes/jquery/menu.js" type="text/javascript"></script>
    <link href="../../includes/41-notepad/css/style.css" rel="stylesheet" />
    <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:left; height: 1000px; width: 1000px; background: url('../image/BlackGeral1.png') repeat; padding: 8px; border-bottom-left-radius: 4px; border-bottom-right-radius: 4px; -moz-border-radius-bottomright: 4px; -moz-border-radius-bottomleft: 4px;">
        <img src="../../images/webapp/icons/prev.png" alt="" onclick="_prev()" />
        Mês <select id="cmbMonth">
            <option label="Janeiro" value="1"></option>
            <option label="Fevereiro" value="2"></option>
            <option label="Março" value="3"></option>
            <option label="Abril" value="4"></option>
            <option label="Maio" value="5"></option>
            <option label="Junho" value="6"></option>
            <option label="Julho" value="7"></option>
            <option label="Agosto" value="8"></option>
            <option label="Setembro" value="9"></option>
            <option label="Outubro" value="10"></option>
            <option label="Novembro" value="11"></option>
            <option label="Dezembro" value="12"></option>
        </select> Ano <input type="text" id="txtYear" style="width:40px;" /> 
        Utilizador 
        <select id="cmbUser">
            <option label="Apenas eu" value="0"></option>
            <option label="Todos" value="1"></option>
        </select>
       <input type="button" value="Procurar" onclick="GetCalendar()" />
        <img src="../../images/webapp/icons/next.png" alt="" onclick="_next()" />
        <div style="float:right;"><a href="Schedule.aspx" target="_self" style="color:#000000;">Procurar Marcações</a></div>
        <!-- CALENDARIO -->
        <div style="border-top: 1px solid #0099cc; border-bottom: 2px solid #0099cc; border-left: 2px solid #0099cc; border-right: 2px solid #0099cc; background-color: #ffffff; color: #ffffff; width: 996px; height: 930px;">
            <div id="divLoadingCalendar" style="background-color:lightgreen; margin:20px 0 0 0;"><img src="../../images/webapp/loading.gif" alt="" /></div>
            <div id="divResult"></div>
        </div>
    </div>
    <div id="divAdmin" style="display:none;"><% Response.Write(Roles.IsUserInRole("Administrator") ? "true" : "false"); %></div>
    <div id="divLoggedUser" style="display:none;"><% Response.Write(HttpContext.Current.User.Identity.Name); %></div>

    <div id="formDetail" style="display: none; text-align:left;">
        <div id="formDetailContent">
            <div id="formContent"></div>
        </div>
        </div>
    <div id="newProcessForm" style="display: none;">
        <div id="newProcessFormContent">
            <h2>Novo Lembrete</h2>
            <label for="txtData">Data</label><div id="divData"></div>
            <div id="divCmbUSer">
                <label for="txtUSer">Utilizador</label> <select id="cmUser"></select>
                <br />
            </div>
            <label for="txtObservation">Descrição</label> <input id="txtObservation" />
            <br />
            <label for="txtRepeat">Repetir X meses</label> <input style="width:50px;" id="txtRepeat" value="0" />
            <br />
            <input type="button" value="Adicionar" onclick="AddAppointment()" />
            <input type="button" value="Cancelar" onclick="CloseForm()" />
        </div>
    </div>

    <script type="text/javascript" language="javascript">
        var _d = 0, _m = 0, _y = 0;

        function ViewForm(date) {
            divLoggedUser
            if ($('#divAdmin').html() == "true") {
                $('#cmUser').val($('#divLoggedUser').html().toLowerCase());
                $('#divCmbUSer').css('display', 'block');
            }
            else {
                //nao é admin
                $('#divCmbUSer').css('display', 'none');
                $('#cmUser').val($('#divLoggedUser').html().toLowerCase());
            }

            $('#divData').html(date);
            $("#newProcessForm").css({'display': 'block','position': 'fixed','top': '0px','left': '0px','padding': '0px','width': '100%','color': '#333','height': '100%','background-image': 'url("../../images/specpopupbg.png")','z-index': '100'});
            $("#newProcessFormContent").css({'position': 'absolute','padding': '10px','width': '400px','left': '50%','margin-left': '-200px','top': '30px','font-weight': 'bold','z-index': '101','background': '#f1f1f1','border': '1px solid #666666'});
        }

        function CloseForm() {
            $('#newProcessForm').css('display', 'none');
        }
        function CloseForm2() {
            _d = 0;
            _m = 0;
            _y = 0;

            $('#formDetail').css('display', 'none');
        }

        function AddAppointment() {
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/AddAppointtment",
                cache: false,
                data: {
                    assigned: $('#cmUser').val(),
                    date: $('#divData').html(),
                    msg: $('#txtObservation').val(),
                    repeat: $('#txtRepeat').val()
                }
            }).done(function (msg) {
                $('#divData').html('');
                $('#txtObservation').val('');
                if (msg.d == "ok") {
                    CloseForm();
                    GetCalendar();
                }
            });
        }

        function _next() {
            var mes = parseInt($('#cmbMonth').val());

            if (mes == 12) {
                var ano = parseInt($('#txtYear').val());
                ano = ano + 1;
                $('#txtYear').val(ano);
                mes = 1;
            }
            else {
                mes = mes + 1;
            }

            $('#cmbMonth').val(mes);

            GetCalendar();
        }
        function _prev() {
            var mes = parseInt($('#cmbMonth').val());

            if (mes == 1) {
                var ano = parseInt($('#txtYear').val());
                ano = ano - 1;
                $('#txtYear').val(ano);
                mes = 12;
            }
            else {
                mes = mes - 1;
            }

            $('#cmbMonth').val(mes);

            GetCalendar();
        }

        function SetChecked(_id) {
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/SetChecked",
                cache:false,
                data: {
                    calendarId: _id
                }
            }).done(function (msg) {
                if (msg.d == "ok") {
                    GetCalendar();

                    //erro!!!! - recarregar o calendario.
                    // possibilidade de reagendar apontamento, talvez abrir outra janela para inserir nova data.
                    OpenDetail();
                    //FillBlockNote();
                }
            });
        }

        function GetCalendar() {
            $('#divResult').html('');
            $('#divLoadingCalendar').css('display', 'block');
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/GetCalendar",
                cache: false,
                data: {
                    month: $('#cmbMonth').val(),
                    year: $('#txtYear').val(),
                    userName: ($('#divAdmin').html() == "true" ? ($('#cmbUser').val() == "0" ? $('#divLoggedUser').html().toLowerCase() : "") : $('#divLoggedUser').html().toLowerCase())
                }
            }).done(function (msg) {
                $('#divLoadingCalendar').css('display', 'none');
                $('#divResult').html(msg.d);
            });
        }

        function OpenDetail(_day, _month, _year) {
            $("#formDetail").css({ 'display': 'block', 'position': 'fixed', 'top': '0px', 'left': '0px', 'padding': '0px', 'width': '100%', 'color': '#333', 'height': '100%', 'background-image': 'url("../../images/specpopupbg.png")', 'z-index': '100' });
            $("#formDetailContent").css({ 'position': 'absolute', 'padding': '10px', 'width': '300px', 'right': '5%', 'margin-left': '-200px', 'top': '30px', 'font-weight': 'bold', 'z-index': '101' });

            FillBlockNote(_day, _month, _year);
        }
        function FillBlockNote(_day, _month, _year)
        {
            _d = _day;
            _m = _month;
            _y = _year;
            $('#divLoadingCalendarDetail').css('display', 'block');

            $.ajax({
                type: "GET", url: "services/CalendarService.svc/GetDaySchedules",
                cache:false,
                data: {
                    day: _day,
                    month: _month,
                    year: _year,
                    userName: ($('#divAdmin').html() == "true" ? ($('#cmbUser').val() == "0" ? $('#divLoggedUser').html().toLowerCase() : "") : $('#divLoggedUser').html().toLowerCase())
                }
            }).done(function (msg) {
                $('#formContent').html(msg.d);
                $('#divLoadingCalendarDetail').css('display', 'none');
            });
        }

        function GetUsers()
        {
            $.ajax({
                type: "GET", url: "services/UserService.svc/GetUsers",
                cache:false
            }).done(function (msg) {
                var items=msg.d;
                for (i = 0; i < items.length; i++) {
                    $('<option/>').val(items[i]).html(items[i]).appendTo('#cmUser');
                }
            });
        }

        function DeleteSchedule(_id) {
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/DeleteSchedule",
                cache:false,
                data: {
                    calendarId: _id
                }
            }).done(function (msg) {
                if (msg.d == "ok") {
                    GetCalendar();
                    FillBlockNote(_d, _m, _y);
                }
            });
        }

        var users;
        $(document).ready(function () {
            var d = new Date();

            var month = d.getMonth() + 1;
            var day = d.getDate();

            $('#txtYear').val(d.getFullYear());
            $('#cmbMonth').val(month);

            GetCalendar();

            GetUsers();
        });
    </script>
</asp:Content>
