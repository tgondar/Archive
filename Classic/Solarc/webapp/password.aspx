<%@ Page Language="C#" AutoEventWireup="true" Inherits="password" Codebehind="password.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:TextBox ID="txtName" runat="server" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="tahoma" Font-Size="Small"></asp:TextBox>
&nbsp;
        <asp:LinkButton ID="lkbReset" runat="server" Font-Names="tahoma" 
            Font-Size="Small" ForeColor="Black" onclick="lkbReset_Click">Reset</asp:LinkButton>
    </div>
    </form>
</body>
</html>
