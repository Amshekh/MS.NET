using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello WinForms";
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		using(Pen pen = new Pen(Color.Red, 3))
		{
			pe.Graphics.DrawRectangle(pen, 30, 30, 130, 30);
		}

		pe.Graphics.DrawString(DateTime.Now.ToString(), this.Font, Brushes.Blue, 40, 40);
	}

	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}










