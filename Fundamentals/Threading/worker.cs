using System;

static class Worker
{
	public static void DoWork(int count) 
	{
		int t = Environment.TickCount + count;

		while(Environment.TickCount < t);
	}
}