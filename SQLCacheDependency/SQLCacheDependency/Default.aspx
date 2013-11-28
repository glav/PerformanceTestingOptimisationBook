<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SQLCacheDependency._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label>Name:</label><asp:Label ID="lblName" runat="server"></asp:Label>
        <br />
        <label>Retrieved from Cache:</label><asp:Label ID="lblTime" runat="server"></asp:Label>
        <hr />
    </div>
    </form>
</body>
</html>
