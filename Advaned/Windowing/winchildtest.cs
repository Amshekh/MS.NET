using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	private Button greetButton;
	private Button quitButton;

	public MainForm()
	{
		this.Text = "Hello WinForms";

		greetButton = new Button();
		greetButton.Text = "Greet";
		greetButton.Size = new Size(60, 25);
		greetButton.Location = new Point(30, 30);
		greetButton.Click += button_Click;
		this.Controls.Add(greetButton);

		quitButton = new Button();
		quitButton.Text = "Quit";
		quitButton.Size = new Size(60, 25);
		quitButton.Location = new Point(100, 30);
		quitButton.Click += button_Click;
		this.Controls.Add(quitButton);
	}

	private void button_Click(object sender, EventArgs e)
	{
		if(sender == greetButton)
			MessageBox.Show("Welcome User", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		else
			this.Close();
	}

	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}








