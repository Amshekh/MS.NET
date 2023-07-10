using System;
using System.Threading.Tasks; // TPL => Thread Parallel Library

static class Test
{
	public static void Main()
	{
		Parallel.For(1, 36, i =>
		{
			Worker.DoWork(10 * i);
			Console.WriteLine("Task<{0}>: Cube of {1} is {2}", Task.CurrentId, i, i * i * i);
		});
	}
}

/* advantage of parallel for is that it can actually utilize multiple processors.i.e. task may be distributed 
to different processors.However if multiple processors are not present and only one processor is
there, then it will perform with threads.

so, if you have system with more than one processor, your program with parallel for loop will run fast. */