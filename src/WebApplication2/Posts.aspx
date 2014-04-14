<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="WebApplication2.Posts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView runat="server" ID="postsGrid"
        DataKeyNames="PostId" ModelType="WebApplication2.Models.Post"
        AllowSorting="true" AutoGenerateColumns="true"
        AutoGenerateEditButton="true" AutoGenerateSelectButton="true"
        SelectMethod="GetPosts" UpdateMethod="UpdatePost" />
    </div>
    </form>
</body>
</html>
