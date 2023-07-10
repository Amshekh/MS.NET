using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp
{
    using ShopDataSetTableAdapters;

    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomerLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (ShopQueries shop = new ShopQueries())
            {
                int? count = shop.ValidateCustomer(CustomerLogin.UserName, CustomerLogin.Password);
                if(count == 1)
                { Session["CustomerId"] = CustomerLogin.UserName;
                    e.Authenticated =true;
                }
            }
        }
    }
}