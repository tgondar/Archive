<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.WebUserControl"
    CodeBehind="WebUserControl.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div>
            <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
            <asp:Panel ID="PanelPrincipal" HorizontalAlign="Center" runat="server" Visible="true" 
                Style="margin-right: 0px" Wrap="False">
                <table>
                    <tr>
                        <td class="style1">
                            <asp:Button ID="ButtonMenuCalendar" runat="server" OnClick="ButtonMenuCalendar_Click"
                                Text="Calendario" />
                        </td>
                        <td class="style2">
                            <asp:Button ID="ButtonMenuList" runat="server" OnClick="ButtonMenuList_Click" Text="Lista Eventos"
                                Width="114px" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonMenuInsert" runat="server" OnClick="ButtonMenuInsert_Click"
                                Text="Inserir Eventos" Width="105px" />
                        </td>
                    </tr>
                </table>
                <asp:TextBox ID="TextBox2" runat="server" Width="186px" CssClass="TextBox" Style="text-align: center;"
                    onkeypress="return (this.value.lenght == 99);" Height="23px" Wrap="False"></asp:TextBox>
                <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" TargetControlID="TextBox2"
                    TodaysDateFormat="dd-MM-yyyy" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/images/webapp/refresh.png"
                    Width="26px" OnClick="ImageButton1_Click" style="margin=0px;"/>
                <asp:Panel ID="PanelViewEvents" runat="server" Visible="False">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="317px"
                        OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" DataKeyNames="EventId"
                        ForeColor="Black" GridLines="Horizontal" Height="21px" CssClass="textLabel">
                        <Columns>
                            <asp:BoundField DataField="Data" HeaderText="Data/Hora">
                                <ItemStyle Height="20px" Width="80px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Subject" HeaderText="Assunto" HtmlEncode="False" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEditEvent" runat="server" CommandName="ev" Text="Mostrar" />
                                </ItemTemplate>
                                <ItemStyle Width="65px" />
                            </asp:TemplateField>
                            <asp:CheckBoxField DataField="Alert" HeaderText="Alerta">
                                <ItemStyle Width="5px" />
                            </asp:CheckBoxField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="VoltarCalendario"
                        Width="113px" CssClass="textLabelB" />
                    <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Adicionar Nesta Data"
                        Width="148px" CssClass="textLabelB" />
                    <br />
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textTextBox"></asp:TextBox><asp:Button
                        ID="Button4" runat="server" OnClick="Button4_Click" Text="Num. Dias" CssClass="textLabelB" />
                </asp:Panel>
                <asp:Panel ID="PanelInsert" runat="server" Style="margin-bottom: 0px" 
                    Visible="False">
                    <asp:Label ID="LabelIsEditing" runat="server" Visible="False"></asp:Label><br />
                    <asp:Label ID="LabelErrorLog" runat="server" CssClass="textLabel"></asp:Label><br />
                    <asp:Label ID="LabelSubject" runat="server" Text="Assunto:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxSubject" runat="server"></asp:TextBox><br />
                    <asp:Label ID="LabelDescription" runat="server" Text="Descricao:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxDescription" runat="server" Height="83px" Width="207px" TextMode="MultiLine"
                        CssClass="textTextBox" onkeypress="return (this.value.length <= 49);"></asp:TextBox><br />
                    <asp:Label ID="LabelDate" runat="server" Text="Data:"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbDateEvent" runat="server" CssClass="textTextBox" Height="22px"
                        onkeypress="return (this.value.lenght == 99);" Width="190px"></asp:TextBox>
                    <cc1:CalendarExtender ID="tbDateEvent_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="tbDateEvent" PopupButtonID="Image1" Format="ddd, dd-MM-yyyy"
                        TodaysDateFormat="ddd, dd-MM-yyyy">
                    </cc1:CalendarExtender>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/images/webapp/calendar_icon.jpg" Height="18px"
                        Width="23px" />
                    <br />
                    <br />
                    <asp:DropDownList ID="DropDownListHour" runat="server" CssClass="textLabelB">
                        <asp:ListItem Value="00">0</asp:ListItem>
                        <asp:ListItem Value="01">1</asp:ListItem>
                        <asp:ListItem Value="02">2</asp:ListItem>
                        <asp:ListItem Value="03">3</asp:ListItem>
                        <asp:ListItem Value="04">4</asp:ListItem>
                        <asp:ListItem Value="05">5</asp:ListItem>
                        <asp:ListItem Value="06">6</asp:ListItem>
                        <asp:ListItem Value="07">7</asp:ListItem>
                        <asp:ListItem Value="08">8</asp:ListItem>
                        <asp:ListItem Value="09">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownListMinute" runat="server" CssClass="textLabelB">
                        <asp:ListItem Value="00" Text="00"></asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:CheckBox ID="CheckBoxAlert" runat="server" Text="Gerar Alerta?" CssClass="textLabel" />
                    <br />
                    <asp:CheckBox ID="CheckBoxPublic" runat="server" CssClass="textLabel" Text="Publico?" />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Gravar" CssClass="textLabelB"
                        Width="154px" />
                    <asp:Button ID="Button5" runat="server" CssClass="textLabelB" OnClick="Button2_Click"
                        Text="Voltar ao Calendario" Width="131px" />
                </asp:Panel>
                <asp:Panel ID="PanelCalendar" runat="server" HorizontalAlign="Center">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
                        BorderStyle="Solid" CellSpacing="1" CssClass="textLabel" Font-Names="Verdana"
                        Font-Size="9pt" ForeColor="Black" Height="214px" NextPrevFormat="ShortMonth"
                        OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                        Width="327px">
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                            ForeColor="White" Height="12pt" />
                    </asp:Calendar>
                    <div style="width:325px;">
                        <div style="float:left;"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Antes</asp:LinkButton></div>
                        <div style="float:right;"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Depois</asp:LinkButton></div>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        Loading...<br />
        <img alt="" src="../../images/webapp/loading.gif" /></ProgressTemplate>
</asp:UpdateProgress>
