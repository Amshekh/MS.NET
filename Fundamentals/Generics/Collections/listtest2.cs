using System;
using System.Collections.Generic;

partial class Interval : IComparable<Interval>
{

	public int CompareTo(Interval other)
	{
		return this.GetTime() - other.GetTime();
	}
}

static class Test
{

	public static void Main()
	{
		List<Interval> store = new List<Interval>();
		store.Add(new Interval(12, 51));
		store.Add(new Interval(14, 42));
		store.Add(new Interval(16, 33));
		store.Add(new BigInterval(1, 15, 24));
		store.Add(new Interval(13, 15));
		
		//store.Sort();
		store.Sort((x, y) => x.Seconds - y.Seconds); // lambda function note: 2 parameters so on lhs () appears.

		foreach(Interval i in store)
			Console.WriteLine(i);

	}
}

