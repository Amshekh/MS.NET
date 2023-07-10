using System;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello WinForms";
	}

	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}


