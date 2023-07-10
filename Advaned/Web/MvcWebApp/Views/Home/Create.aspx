<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcWebApp.Models.OrderDetail>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Create</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.5.1.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
    <h1>Add New Product</h1>
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>New Product Info</legend>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.OrderDate) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.OrderDate) %>
                <%: Html.ValidationMessageFor(model => model.OrderDate) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CustomerId) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.CustomerId) %>
                <%: Html.ValidationMessageFor(model => model.CustomerId) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductNo) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.ProductNo) %>
                <%: Html.ValidationMessageFor(model => model.ProductNo) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Quantity) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Quantity) %>
                <%: Html.ValidationMessageFor(model => model.Quantity) %>
            </div>
    
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</body>
</html>
