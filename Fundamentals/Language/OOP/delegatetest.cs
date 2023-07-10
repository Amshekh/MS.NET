using System;

delegate bool Filter(int value);

static class Algorithm
{

	public static int AddAll(int last)
	{
		int total = 0;

		for(int i = 1; i <= last; i++)
		{
			total += i;
		}
		
		return total;
	}

	public static int AddIf(int last, Filter check)
	{
		int total = 0;

		for(int i =1; i <= last; i++)
		{
			if(check(i))  // check.Invoke(i)
				total += i;
		}

		return total;
	}
}

static class Test
{
	private static bool IsOdd(int value)
	{
		return (value & 1) == 1; // logic to find odd no.it's 60 times faster.
	}

	class IsMultiple
	{
		private int target;

		public IsMultiple(int t)
		{
			target = t;
		}
		
		public bool Verify(int value)
		{
			return (value % target) == 0;
		}
	}

	public static void Main(string[] args)
	{
		int limit = args.Length == 0 ? 100 : Convert.ToInt32(args[0]);
		
		Console.WriteLine("Sum of all integers upto {0} is {1}", limit, Algorithm.AddAll(limit));
		Console.WriteLine("Sum of Odd integers upto {0} is {1}", limit, Algorithm.AddIf(limit, IsOdd));
		Console.WriteLine("Sum of multiples of 5 upto {0} is {1}", limit, Algorithm.AddIf(limit, new IsMultiple(5).Verify));

	}
}