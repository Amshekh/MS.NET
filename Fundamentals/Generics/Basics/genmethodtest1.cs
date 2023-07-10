using System;

static class Test
{

	private static T Select<T>(int sign, T first, T second, T third)
	{
		if(sign < 0)
			return first;
		if(sign == 0)
			return second;
		return third;
	}

	public static void Main(string[] args)
	{
	
		int s = Convert.ToInt32(args[0]);

		string ss = Select(s, "Monday", "Wednesday", "Friday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = Select(s, 12.34, 23.45, 34.56);
		Console.WriteLine("Selected double = {0}", sd);

		Interval si = Select(s, new Interval(4, 15), new BigInterval(1, 2, 30), new Interval(5, 45));
		Console.WriteLine("Selected interval = {0}", si);

		long sl = Select(s, 1234L, 2345L, 0xABCDL);
		Console.WriteLine("Selected long = {0}", sl);
	}
}