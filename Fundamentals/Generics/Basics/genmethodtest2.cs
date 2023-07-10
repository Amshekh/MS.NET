using System;

partial class Interval : IComparable<Interval>
{
	public int CompareTo(Interval other)
	{
		return this.GetTime() - other.GetTime();
	}
}

static class Test
{

	private static T Maximum<T>(T first, T second) where T : IComparable<T>
	{
		if(first.CompareTo(second) > 0)
			return first;
		return second;
		
	}

	public static void Main()
	{
	
		double md = Maximum(8.21, 9.45);
		Console.WriteLine("Selected double = {0}", md);

		string ms = Maximum("Monday", "Friday");
		Console.WriteLine("Maximum string = {0}", ms);

		Interval mi = Maximum(new Interval(5, 89), new Interval(7, 15));
		Console.WriteLine("Maximum interval = {0}", mi);
	}
}