using System;
using System.Threading;

static class Test
{
	private static void PrintJob(object arg)
	{
		for(int i = 1; i <= 20; i++)
		{
			Console.WriteLine("{0}:{1} from thread<{2}>", i, arg, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(10 * i);
		}
	}

	public static void Main()
	{
		Console.WriteLine("Enter any key to exit.");

		ThreadPool.QueueUserWorkItem(PrintJob, "Hello");
		ThreadPool.QueueUserWorkItem(PrintJob, "Welcome");

		Console.ReadLine();
	}
}

//as soon as we press any key we see main function exits and there will be no further execution of printjob function.