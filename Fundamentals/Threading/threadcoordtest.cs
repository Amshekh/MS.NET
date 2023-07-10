using System;
using System.Threading;

static class Test
{
	private static volatile int value = -1;
	private static object coordinator = new object();

	private static void ConsumerProc()
	{
		do
		{
			lock(coordinator)
			{
				Monitor.Wait(coordinator);
				Console.WriteLine("Processed value = {0}", value * value);
			}
		}
		while(value != 0);
	}

	private static void ProducerProc()
	{
		for(int i = 10; i >= 0; i--)
		{
			Worker.DoWork(100 * (i + 1));
			lock(coordinator)
			{
				value = i;
				Monitor.Pulse(coordinator);
			}
		}
	}

	public static void Main()
	{
		Thread th = new Thread(ConsumerProc);
		th.Start();
		
		ProducerProc();
	}	
}















