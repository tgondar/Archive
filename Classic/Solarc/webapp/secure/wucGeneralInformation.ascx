<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucGeneralInformation"
    CodeBehind="wucGeneralInformation.ascx.cs" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<div style="height:210px;">
<div style="float:left;">
    <asp:Chart ID="Chart1" runat="server"
        Height="200px" BorderWidth="2" BorderColor="26, 59, 105" 
        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineWidth="0" 
        Width="400px">
        <Titles>
            <asp:Title ShadowColor="32, 0, 0, 0" Font="Tahoma, 15px, style=Bold" ShadowOffset="3"
                Text="Informação Processos" Name="Title1" ForeColor="26, 59, 105">
            </asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" CustomProperties="DrawingStyle=LightToDark, PieDrawingStyle=Concave">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
                <Area3DStyle Rotation="20" IsRightAngleAxes="False" WallWidth="0" />
                <AxisY LineColor="64, 64, 64, 64">
                    <LabelStyle Font="Tahoma, 8px, style=Bold" />
                    <MajorGrid LineColor="64, 64, 64, 64" />
                </AxisY>
                <AxisX LineColor="64, 64, 64, 64">
                    <LabelStyle Font="Tahoma, 8px, style=Bold" />
                    <MajorGrid LineColor="64, 64, 64, 64" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</div>

<div style="float:left; margin:0 0 0 10px;">
    <asp:Chart ID="Chart2" runat="server"
        Height="200px" BackSecondaryColor="White" BorderWidth="2" BorderColor="26, 59, 105" 
        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineWidth="0" 
        Width="400px">
        <Titles>
            <asp:Title ShadowColor="32, 0, 0, 0" Font="Tahoma, 15px, style=Bold" ShadowOffset="3"
                Text="Processos/Mandatário" Name="Title1" ForeColor="26, 59, 105">
            </asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1" CustomProperties="DrawingStyle=LightToDark, PieDrawingStyle=Concave">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
                <Area3DStyle Rotation="20" IsRightAngleAxes="False" WallWidth="0" />
                <AxisY LineColor="64, 64, 64, 64">
                    <LabelStyle Font="Tahoma, 8px, style=Bold" />
                    <MajorGrid LineColor="64, 64, 64, 64" />
                </AxisY>
                <AxisX LineColor="64, 64, 64, 64">
                    <LabelStyle Font="Tahoma, 8px, style=Bold" />
                    <MajorGrid LineColor="64, 64, 64, 64" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</div>
</div>
<div>
    <asp:Label ID="lblUser" CssClass="textLabel" runat="server"></asp:Label>
</div>





