<%@ Page Title="Default - DBWebApp" Language="C#" MasterPageFile="~/SalesSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DBWebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Available Products" 
        Font-Bold="True" Font-Size="X-Large" ForeColor="#333333"></asp:Label>
    <p>
        <asp:GridView ID="productsGridView" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ProductNo" DataSourceID="productlDataSource" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ProductNo" HeaderText="Product No" ReadOnly="True" 
                    SortExpression="ProductNo" />
                <asp:BoundField DataField="Price" HeaderText="Unit Price" 
                    SortExpression="Price" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Stock" HeaderText="Current Stock" 
                    SortExpression="Stock" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="productlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ShopConnectionString %>" 
            SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx">Registered Customer LogIn</asp:HyperLink>
    </p>
</asp:Content>
