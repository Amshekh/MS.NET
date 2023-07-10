using System;
using System.Collections.Generic;

static class Test
{
	public static void Main()
	{
		IList<Interval> store = new Interval[]
		{
		
			new Interval(12, 51),
			new Interval(14, 42),		
			new Interval(16, 33),
			new BigInterval(1, 15, 24),
			new Interval(14, 61),
			new Interval(11, 111),   // note: arrays allows repeatition
		};

		foreach(Interval i in store)
			Console.WriteLine(i);

		Console.WriteLine("Third entry = {0}", store[2]);
	}
}