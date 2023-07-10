using System;
using System.Threading;

static class Test
{
	private static int count = 20;

	private static void HelloProc()
	{
		for(int i = 1; i <= count / 2; i++)
		{
			Console.WriteLine("Hello:{0} from thread<{1}>", i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(5 * i);
		}

		try
		{
			Thread.Sleep(5000);
		}
		catch(ThreadInterruptedException)
		{
   			Console.WriteLine("Sleep interuppted!");
		}

		Console.WriteLine("GoodBye.");
	}

	private static void WelcomeProc()
	{
		for(int i = count; i > 0; i--)
		{
			Console.WriteLine("Welcome:{0} from thread <{1}>", i,Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(5 * i);
		}
	}

	public static void Main()
	{
		Thread th = new Thread(HelloProc);
		th.Start();

		WelcomeProc();

		th.Interrupt();
	}
}