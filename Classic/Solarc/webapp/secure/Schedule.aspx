<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/secure/mp.master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Solarc.webapp.secure.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContentTitle">
        <div class="divContent">
            1. Opções de Pesquisa
        </div>
    </div>
    <div class="divContentFields">
        Dia <input type="text" id="txtDay" style="width:30px;" /> Mes <input type="text" id="txtMonth" style="width:30px;" /> Ano <input type="text" id="txtYear" style="width:30px;" /> Utilizador <select id="cmUser"></select> Descrição <input type="text" id="txtObservation" /> 
        <input type="button" id="btSearch" value="Procurar" onclick="GetCalendar()" />
        <div id="divResult"></div>
    </div>
    <div id="divAdmin" style="display: none;"><% Response.Write(Roles.IsUserInRole("Administrator") ? "true" : "false"); %></div>
    <div id="divLoggedUser" style="display: none;"><% Response.Write(HttpContext.Current.User.Identity.Name); %></div>

    <script type="text/javascript">
        function GetUsers() {
            $.ajax({
                type: "GET", url: "services/UserService.svc/GetUsers",
                cache: false
            }).done(function (msg) {
                var items = msg.d;
                $('<option/>').val('').html('Todos').appendTo('#cmUser');
                for (i = 0; i < items.length; i++) {
                    $('<option/>').val(items[i]).html(items[i]).appendTo('#cmUser');
                }
            });
        }

        function GetCalendar() {
            $('#divResult').html('');
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/GetSchedules",
                cache: false,
                data: {
                    day: ($('#txtDay').val() == '' ? 0 : $('#txtDay').val()),
                    month: ($('#txtMonth').val() == '' ? 0 : $('#txtMonth').val()),
                    year: ($('#txtYear').val() == '' ? 0 : $('#txtYear').val()),
                    userName: ($('#divAdmin').html() == "true" ? $('#cmUser').val() : $('#divLoggedUser').html().toLowerCase()),
                    observation: $('#txtObservation').val(),
                }
            }).done(function (msg) {
                $('#divResult').html(msg.d);
            });
        }

        function DeleteSchedule(_id) {
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/DeleteSchedule",
                cache: false,
                data: {
                    calendarId: _id
                }
            }).done(function (msg) {
                GetCalendar();
            });
        }

        function SetChecked(_id) {
            $.ajax({
                type: "GET", url: "services/CalendarService.svc/SetChecked",
                cache: false,
                data: {
                    calendarId: _id
                }
            }).done(function (msg) {
                if (msg.d == "ok") {
                    GetCalendar();

                    GetCalendar();
                }
            });
        }

        $(document).ready(function () {
            GetUsers();
        });
    </script>
</asp:Content>
