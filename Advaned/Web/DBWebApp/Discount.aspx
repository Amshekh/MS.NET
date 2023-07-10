<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Discount.aspx.cs" Inherits="DBWebApp.Discount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Discount - DBWebApp</title>
</head>
<body>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label2" runat="server" Text="Catalog Price:"></asp:Label>
            <asp:TextBox ID="catalogPriceTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="goButton" runat="server" Text="Go!" onclick="goButton_Click" />
            <p>
                <asp:Label ID="resultLabel" runat="server" Font-Bold="True"></asp:Label>
            </p>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
