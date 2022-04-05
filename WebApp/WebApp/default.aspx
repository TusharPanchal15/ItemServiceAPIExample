<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>Enter Name - <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox></div>
            <br />
            <div>Enter Template Id - <asp:TextBox ID="txtTemplateId" runat="server" Text="{76036F5E-CBCE-46D1-AF0A-4143F9B557AA}"></asp:TextBox></div>
            <br />
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Item"/>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
