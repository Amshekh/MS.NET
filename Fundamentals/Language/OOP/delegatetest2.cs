using System;

delegate bool Filter(int value);

delegate object Transformer(string text);

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
			if(check(i)) // check.Invoke(i)
				total += i;
		}

		return total;
	}

	public static void PrintTransformed(string[] items, Transformer change)
	{
		foreach(string item in items)
			Console.WriteLine(change(item));
	}
}

static class Test
{
	private static bool IsOdd(int value)
	{
		return (value & 1) == 1;
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

	private static string Enquote(object obj)
	{
		return "'" + obj + "'";
	}

	public static void Main(string[] args)
	{
		int limit = args.Length == 0 ? 100 : Convert.ToInt32(args[0]);

		Console.WriteLine("Sum of all integers upto {0} is {1}", limit, 
			Algorithm.AddAll(limit));

		Console.WriteLine("Sum of odd integers upto {0} is {1}", limit, 
			Algorithm.AddIf(limit, IsOdd));

		Console.WriteLine("Sum of multiples of 5 upto {0} is {1}", limit, 
			Algorithm.AddIf(limit, new IsMultiple(5).Verify));

		Console.WriteLine("Sum of all integers greater than {0} upto {1} is {2}", limit / 2, limit,
			Algorithm.AddIf(limit, delegate(int value)
			{
				return value > limit / 2; // usage of anonymous method(it's alternative is lambda function below)
			}));

		Console.WriteLine("Sum of all even integers upto {0} is {1}", limit, 
			Algorithm.AddIf(limit, x => (x & 2) == 0));      // here we use lambda function which at this point generates result for mentioned expression

		string[] items = {"Monday", "Tuesday", "Wednesday"};
		Algorithm.PrintTransformed(items, Enquote);

	}

}