using System;
using System.Collections.Generic;

static class Test
{
	public static void Main()
	{
		ICollection<Interval> store = new HashSet<Interval>();
		store.Add(new Interval(12, 51));
		store.Add(new Interval(14, 42));
		store.Add(new Interval(16, 33));
		store.Add(new BigInterval(1, 15, 24));
		store.Add(new Interval(13, 15));
		store.Add(new Interval(11, 111)); // this will not appear in o/p b/c hashset does not allow repeation

		foreach(Interval i in store)
			Console.WriteLine(i);
	}
}