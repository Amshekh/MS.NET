using System;
using System.Threading;

static class Test
{
	private static int count = 20;

	private static void GreetProc(object arg)
	{
		for(int i = 1; i <= count; i++)
		{
			Console.WriteLine("{0}:{1} from thread<{2}>", arg, i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(5 * i);
		}
	}

	private static void WelcomeProc()
	{
		for(int i = count / 2; i > 0; i--)
		{
			Console.WriteLine("Welcome:{0} fro thread<{1}>", i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(5 * i);
		}
	}

	public static void Main()
	{
		Thread th = new Thread(GreetProc);
		th.IsBackground = true;
		th.Start("Hello");

		WelcomeProc();
	}
}