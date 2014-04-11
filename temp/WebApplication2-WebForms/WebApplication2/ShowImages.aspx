<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="ShowImages.aspx.cs" Inherits="WebApplication2.ShowImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView runat="server" ID="dataListViewImages"
                ItemType="System.String"
                SelectMethod="GetImageUrls">
                <ItemTemplate>
                    <img src="<%# Container.DataItem as string %>" />
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
