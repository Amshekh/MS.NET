using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebApp
{
	public partial class WebFormTest2 : Page
	{
		protected Label greetLabel;
		protected TextBox nameTextBox;

		protected void greetButton_Click(object sender, EventArgs e)
		{
			greetLabel.Text = "Hello " + nameTextBox.Text;
		}
	}
}


