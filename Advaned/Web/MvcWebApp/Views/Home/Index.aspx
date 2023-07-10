<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWebApp.Models.Product>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
</head>
<body>
    <h1>Product Details</h1>
    
    <table border="1" cellpadding="4" cellspacing="0">
        <tr>
            <th>
                Product No
            </th>
            <th>
                Price
            </th>
            <th>
                Stock
            </th>
            <th>
                Show
            </th>
        </tr>
    
    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.ProductNo) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Price) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Stock) %>
            </td>
            <td>
                 <%: Html.ActionLink("Order", "Details", new { id=item.ProductNo }) %>
            </td>
        </tr>
    <% } %>
    
    </table>
    <p>
        <%: Html.ActionLink("Add New Product", "Create") %>
    </p>
</body>
</html>
