﻿<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="DownloadImage.aspx.cs" Inherits="WebApplication2.DownloadImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="textUrl" runat="server" Text="https://dl.dropboxusercontent.com/u/40134810/demoFiles/images/01.jpg" 
            TextMode="MultiLine" Height="200" Width="1000"/>
        
        <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />



    </div>
    </form>
</body>
</html>