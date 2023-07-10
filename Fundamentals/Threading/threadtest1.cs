using System;
using System.Threading; // for all threading we have to use this.

static class Test
{
	private static int count = 20;

	private static void HelloProc()
	{
		for(int i = 1; i <= count; i++)
		{
			Console.WriteLine("Hello:{0} from thread<{1}>", i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(i * 5);
		}
	}

	private static void WelcomeProc()
	{
		for(int i = count / 2; i > 0; i--)
		{
			Console.WriteLine("Welcome:{0} from thread<{1}>", i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(i * 5);
		}
	}

	public static void Main()
	{
		Thread th = new Thread(HelloProc);
		th.Start();

		WelcomeProc();
	}
}


/*
In windows we have primary thread which is given id 1, thread with id 2 for its internal purpose.
so a new thread will be given id 3 onwards.

note: id's are generated at irrespective of order i.e ascending, descending , last name etc. purpose is to have unique id's just like roll no.s
*/