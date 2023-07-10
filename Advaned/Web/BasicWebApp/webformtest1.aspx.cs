using System;

namespace BasicWebApp
{
	public partial class WebFormTest1 : System.Web.UI.Page
	{
		protected void greetButton_Click(object sender, EventArgs e)
		{
			greetLabel.Text = "Hello " + nameTextBox.Text;
		}
	}
}


