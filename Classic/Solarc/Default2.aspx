<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="Default2" Codebehind="Default2.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Height="222px" TextMode="MultiLine" 
            Width="517px"></asp:TextBox>
        <br />    
    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Doc 2</asp:LinkButton>
    
    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Doc 3 XHTML</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
