<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="GetImages.aspx.cs" Inherits="WebApplication2.GetImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="textUrls" TextMode="MultiLine" Height="150" Width="1000"
            Text="https://dl.dropboxusercontent.com/u/40134810/demoFiles/images/01.gif" />

        <asp:Button runat="server" ID="btnGetImg" Text="Download" OnClick="btnGetImg_Click" />

        <asp:TextBox runat="server" ID="textUrlsAsync" TextMode="MultiLine" Height="150" Width="1000"
            Text="https://dl.dropboxusercontent.com/u/40134810/demoFiles/images/05.gif" />

        <asp:Button runat="server" ID="btnGetImgAsync" Text="Download" OnClick="btnGetImgAsync_Click"  />
    </div>
    </form>
</body>
</html>
