using System;

static class Test
{
	private static string Select(int sign, string first, string second, string third)
	{
		if(sign < 0)
			return first;
		if(sign == 0)
			return second;
		return third;
	}

	private static double Select(int sign, double first, double second, double third)
	{
		if(sign < 0)
			return first;
		if(sign == 0)
			return second;
		return third;
	}

	private static void Main(string[] args)
	{
	
		int s = Convert.ToInt32(args[0]);
		
		string ss = (string) Select(s, "Monday", "Wednesday", "Friday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = (double) Select(s, 11.11, 12.12, 15.56);
		Console.WriteLine("Selected double = {0}", sd);
	}
}