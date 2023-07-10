using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBWebApp
{
    public partial class Discount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            decimal price = Convert.ToDecimal(catalogPriceTextBox.Text);
            decimal rate = price < 5000 ? 5.0M : 7.5M;
            decimal cash = price * (1 - rate / 100);

            resultLabel.Text = string.Format("Cash Price is {0:0.00}", cash);
        }
    }
}