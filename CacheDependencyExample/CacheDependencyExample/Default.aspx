<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CacheDependencyExample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #control-panel ul, #dataResults ul { list-style:none; }
        #control-panel ul li { display:inline; padding-left:10px; }

        #dataResults ul li { display:block; padding-left:10px; }
        #dataResults label { padding-right:5px; color:Blue;}
        #dataResults span {font-weight:bold; color:Green;  }
        
        table { margin:auto;}
        th { font-weight:bold; text-decoration:underline; padding:0px 10px 2px 2px;}
        tr {  }
        td {  }
        td.instance-time { font-weight:bold; padding-left:20px;  }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Cache Dependency Example</h1>
        <fieldset id="control-panel">
            <legend>Control Panel</legend>
            <ul>
                <li>
                    <asp:Button ID="btnGetData" runat="server" Text="Get Data" 
                        onclick="btnGetData_Click" />
                </li>
                <li>
                    <asp:Button ID="btnFillCache" runat="server" Text="Fill Cache" 
                        onclick="btnFillCache_Click" />
                </li>
                <li>
                    <label>Cache Data Expiry Time (in seconds):</label>
                    <asp:TextBox ID="txtExpiryTime" runat="server" Text="10" />
                </li>
            </ul>
        </fieldset>

        <div id="dataResults">
            <ul>
                <li>
                    <label>Data Retrieved from:</label>
                    <span><%# DataContainer.SourceOfData %></span>
                </li>
                <li>
                    <label>Query Time took:</label>
                    <span><%# string.Format("{0:0.00} minutes, {1:0.00} seconds &amp; {2:0.00} milliseconds", 
                                DataContainer.QueryTime.Minutes,
                                DataContainer.QueryTime.Seconds, 
                                DataContainer.QueryTime.Milliseconds)%></span>
                </li>
                <li>
                    <label>Current Time is:</label>
                    <span><%# DateTime.Now.ToString("HH:mm:ss") %></span>
                </li>
            </ul>
            
            <asp:Repeater ID="rptData" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Description</th>
                                <th>Instance Time</th>
                            </tr>
                        </thead>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Description")%></td>                    
                        <td class="instance-time"><%# ((DateTime)Eval("InstanceTime")).ToString("HH:mm:ss")%></td>                    
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
