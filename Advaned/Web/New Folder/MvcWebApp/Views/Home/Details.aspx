<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcWebApp.Models.OrderDetail>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Details</title>
</head>
<body>
    <h1>Orders for Product <%:ViewData["ProductNo"] %></h1>

    <table border="1" cellpadding="4" cellspacing="0">
        <tr>
            <th>
                Order No
            </th>
            <th>
                Order Date
            </th>
            <th>
                Customer Id
            </th>
            <th>
                Quantity
            </th>
        </tr>
    
    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.OrderNo) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.OrderDate) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.CustomerId) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Quantity) %>
            </td>
        </tr>
    <% } %>
    
    </table>
    <p>
        <%: Html.ActionLink("Back to Product List", "Index") %>
    </p>
</body>
</html>
