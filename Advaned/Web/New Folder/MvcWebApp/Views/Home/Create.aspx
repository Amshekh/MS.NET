<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcWebApp.Models.ProductDto>" %>

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
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Price) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Stock) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Stock) %>
                <%: Html.ValidationMessageFor(model => model.Stock) %>
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
