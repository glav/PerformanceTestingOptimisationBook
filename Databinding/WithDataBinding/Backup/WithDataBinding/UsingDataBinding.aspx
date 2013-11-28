<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingDataBinding.aspx.cs" Inherits="WithDataBinding._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <label>Title:&nbsp;</label>
            <label><%# BodyTitle %></label>
            <label>Version:&nbsp;</label>
            <span><%# Version %></span>
            <p><%# Comments %></p>
        </div>

        <asp:Repeater ID="rpt1" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            
            <ItemTemplate>
                <li runat="server" style='<%# Eval("ItemColor") %>'>
                    <span>Author:</span>
                    <span><%# Eval("AuthorName") %></span>
                    <span>Book:</span>
                    <span><%# Eval("BookTitle") %></span>
                </li>
            </ItemTemplate>
            
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
