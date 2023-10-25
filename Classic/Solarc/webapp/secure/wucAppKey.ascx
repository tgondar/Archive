<%@ Control Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.wucAppKey"
    CodeBehind="wucAppKey.ascx.cs" %>
<div style="float:right; background-color:Red; color:White; padding:5px;">
    <asp:Label ID="Label1" runat="server" Text="Insira os códigos correspondentes:"></asp:Label>
    <br />
    <asp:Label ID="lblV1" runat="server"></asp:Label>
    &nbsp;<asp:TextBox CssClass="textTextBox" ID="txtV1" runat="server" BorderColor="Black"
        BorderStyle="Solid" BorderWidth="1px" MaxLength="1" Width="15px"></asp:TextBox>
    &nbsp;<asp:Label ID="lblV2" runat="server"></asp:Label>
    &nbsp;<asp:TextBox CssClass="textTextBox" ID="txtV2" runat="server" BorderColor="Black"
        BorderStyle="Solid" BorderWidth="1px" MaxLength="1" Width="15px"></asp:TextBox>
    &nbsp;<asp:Label ID="lblV3" runat="server"></asp:Label>
    &nbsp;<asp:TextBox CssClass="textTextBox" ID="txtV3" runat="server" BorderColor="Black"
        BorderStyle="Solid" BorderWidth="1px" MaxLength="1" Width="15px"></asp:TextBox>
</div>
