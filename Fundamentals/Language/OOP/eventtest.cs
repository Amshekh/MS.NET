using System;

class MessageEventArgs : EventArgs
{
	public readonly string Text;
	public readonly string From;

	public MessageEventArgs(string text, string from)
	{
		Text = text;
		From = from;
	}
}

delegate void MessageEventHandler(object sender, MessageEventArgs e); // delegate keyword used for event

class Messenger
{

	public string User{get; set;}

	public event MessageEventHandler Receive;

	private void OnReceive(string text, string from)
	{
		if(Receive != null)
			Receive(this, new MessageEventArgs(text, from));
	}

	public void Send(string text, Messenger to)
	{
		to.OnReceive(text, User);
	}
}

class MessengerApp
{

	private Messenger first = new Messenger{User="Jeff"};
	private Messenger second = new Messenger{User="John"};

	private void first_Receive(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}

	public void Run()
	{
		first.Receive += first_Receive;
		first.Receive += delegate(object sender, MessageEventArgs e)
		{
			Console.WriteLine("Jeff received '{0}' from {1}", e.Text, e.From);
		};

		second.Send("Today is Thursday", first);
		int t = Environment.TickCount + 5000;
		while(Environment.TickCount < t);
		second.Send("Tommorow is Friday", first);
	}
	
}

static class Test
{

	public static void Main()
	{
		MessengerApp app = new MessengerApp();
		app.Run();
	}

}