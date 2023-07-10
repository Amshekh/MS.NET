using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp
{
    using ShopDataSetTableAdapters;

    public partial class WebForm3 : System.Web.UI.Page
    {
        private string customerId = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = (string)Session["CustomerId"];

            if (customerId == null)
                Response.Redirect("Login.aspx");
            else
                CustomerIdLabel.Text = customerId;
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            int productNo = Convert.ToInt32(productDropDownList.Text);
            int quantity = Convert.ToInt32(quantityTextBox.Text);
            int? orderNo;

            using (ShopQueries shop = new ShopQueries())
            {
                shop.PlaceNewOrder(customerId, productNo, quantity, out orderNo);
            }

            scriptLiteral.Text = string.Format("alert('New order number is {0}')", orderNo);
        }

        protected void logoutLinkButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Server.Transfer("Default.aspx");
        }
    }
}