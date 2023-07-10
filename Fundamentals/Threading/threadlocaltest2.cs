using System;
using System.Threading;


static class PrintItem
{	
	[ThreadStatic]  // now clr will take care after applying this attribute.
	
	private static string text = null;
	
	public static string Text
	{
		get {return text;}
		set {text = value;}
	}

}

static class Printer
{
	public static void Print(int copies)
	{
		for(int i = 1; i <= copies; i++)	
		{
			Console.WriteLine("Printing copy:{0} of '{1}' for thread<{2}>", i, PrintItem.Text, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(10 * i);
		}
	}
}

static class Test
{
	public static void Main()
	{
		Thread th = new Thread(delegate()
		{
			PrintItem.Text = "Monday";
			Printer.Print(10);
		});
		th.Start();

		PrintItem.Text = "Wednesday";
		Printer.Print(10);
	}
}