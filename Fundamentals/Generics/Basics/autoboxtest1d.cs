using System;

static class Test
{
	private static object Select(int sign, object first, object second, object third) // object type.
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

		Interval si = (Interval) Select(s, new Interval(4, 15), new BigInterval(1, 2, 30), new Interval(5, 45));
		Console.WriteLine("Selected Interval = {0}", si);
	}
}

/* 
	compile with interval.cs 
	run with 0/-ve/+ve no.

*/