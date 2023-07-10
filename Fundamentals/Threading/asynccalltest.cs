using System;
using System.Threading;
using RandomAverageStart = System.Func<int, int, long, double>;

static class Test
{
	private static double RandomAverage(int low, int high, long count)
	{
		Random rnd = new Random();
		double total = 0;


		for(long i = 0; i < count; i++)
			total += rnd.Next(low, high + 1);

		return total / count;
	}

	private static void RandomAverageCompleted(IAsyncResult result)
	{
		Console.WriteLine(result.AsyncState);
	}
	
	private static void Main()
	{
		Console.Write("Processing, please wait.");

		RandomAverageStart ras = RandomAverage;
		IAsyncResult job = ras.BeginInvoke(1, 99, 500000000L, RandomAverageCompleted, "Done!");
		while(!job.IsCompleted)
		{
			Console.Write('*');
			Thread.Sleep(300);
		}
		double avg = ras.EndInvoke(job);

		Console.WriteLine();
		Console.WriteLine("Result = {0}", avg);
	}
}

