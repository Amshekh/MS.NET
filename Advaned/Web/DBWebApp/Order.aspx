<%@ Page Title="Order - DBWebApp" Language="C#" MasterPageFile="~/SalesSite.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="DBWebApp.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Welcome Customer" Font-Bold="True" 
        Font-Size="X-Large" ForeColor="#993300"></asp:Label>
    <asp:Label ID="CustomerIdLabel" runat="server" Font-Bold="True" 
        Font-Size="X-Large" ForeColor="#CC0000"></asp:Label>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Product No:" Width="100px"></asp:Label>
        <asp:DropDownList ID="productDropDownList" runat="server" Width="100px" 
            DataSourceID="productlDataSource" DataTextField="ProductNo" 
            DataValueField="ProductNo">
        </asp:DropDownList>
        <asp:SqlDataSource ID="productlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ShopConnectionString %>" 
            SelectCommand="SELECT [ProductNo] FROM [Product]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Quantity:" Width="100px"></asp:Label>
        <asp:TextBox ID="quantityTextBox" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="quantityTextBox" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="OrderButton" runat="server" Text="Order" 
            onclick="OrderButton_Click" />
    </p>
    <script type="text/javascript">
        <asp:Literal Id="scriptLiteral" runat="server"></asp:Literal>
    </script>
    <p>
        <asp:LinkButton ID="logoutLinkButton" runat="server" CausesValidation="False" 
            onclick="logoutLinkButton_Click">Customer LogOut</asp:LinkButton>
    </p>
</asp:Content>
