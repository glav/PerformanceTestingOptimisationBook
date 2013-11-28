<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarkupAndResponseWrite.aspx.cs" Inherits="WithDataBinding.MarkupAndResponseWrite" %>

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
            <label><%= BodyTitle %></label>
            <label>Version:&nbsp;</label>
            <span><%= Version %></span>
            <p><%= Comments %></p>
        </div>

                <ul>
<% foreach (var item in DataItems)
   { %>
                    <li style="<%= item.ItemColor %>">
                        <span>Author:</span>
                        <span><%= item.AuthorName %></span>
                        <span>Book:</span>
                        <span><%= item.BookTitle %></span>
                    </li>
<% } %>    
                </ul>

    </div>
    </form>
</body>
</html>
