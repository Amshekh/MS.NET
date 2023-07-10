using System;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello WinForms";
	}

	protected override void OnClosed(EventArgs e)
	{
		MessageBox.Show("Goodbye User!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		base.OnClosed(e);
	}

	protected override void WndProc(ref Message m)
	{
		if(m.Msg == 0xA3) // WM_NCLBUTTONDBLCLK
			this.WindowState = FormWindowState.Minimized;
		else
			base.WndProc(ref m);
	}

	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}









