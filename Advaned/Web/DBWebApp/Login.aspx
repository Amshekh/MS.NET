<%@ Page Title="Login - DBWebApp" Language="C#" MasterPageFile="~/SalesSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DBWebApp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Welcome Customer" Font-Bold="True" 
        Font-Size="X-Large" ForeColor="#CC6600"></asp:Label><br></br>
    <asp:Login ID="CustomerLogin" runat="server" BackColor="#F7F6F3" 
        BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
        DisplayRememberMe="False" Font-Names="Verdana" Font-Size="0.8em" 
        ForeColor="#333333" UserNameLabelText="Customer ID:" 
        DestinationPageUrl="Order.aspx" onauthenticate="CustomerLogin_Authenticate">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
    </asp:Login>
</asp:Content>
