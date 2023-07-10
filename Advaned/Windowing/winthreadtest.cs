using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello WinForms";
		ThreadPool.QueueUserWorkItem(Clock);
	}

	private void Clock(object state)
	{
		for(;;)
		{
			Thread.Sleep(1000);
			UpdateUI();
		}
	}

	private void UpdateUI()
	{
		if(this.InvokeRequired)
			this.Invoke(new MethodInvoker(UpdateUI));
		else
			this.Refresh();
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










