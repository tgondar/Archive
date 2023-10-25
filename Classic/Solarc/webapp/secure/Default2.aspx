<%@ Page Language="C#" AutoEventWireup="true" Inherits="Solarc.webapp.secure.Default2" Codebehind="Default2.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Calendar ID="Calendar1" runat="server" 
            onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AC.asmx" />
        </Services>
        </asp:ScriptManager>
        <asp:TextBox runat="server" ID="myTextBox" Width="300" autocomplete="off" />
        <cc1:autocompleteextender runat="server" id="autoComplete1" targetcontrolid="myTextBox"
            servicepath="~/AC.asmx" servicemethod="Court" minimumprefixlength="2"
            completioninterval="1000" enablecaching="true" completionsetcount="12" />
    </div>
    </form>
</body>
</html>
