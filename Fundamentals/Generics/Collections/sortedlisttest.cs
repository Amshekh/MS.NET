using System;
using System.Collections.Generic;

static class Test
{
	public static void Main()
	{
		IDictionary<string, Interval> store = new SortedList<string, Interval>();
		store.Add("monday", new Interval(12, 51));
		store.Add("tuesday", new Interval(14, 42));
		store.Add("wednesday", new Interval(16, 33));
		store.Add("thursday", new BigInterval(1, 15, 24));
		store.Add("friday", new Interval(13, 15));
		//store.Add("monday", new Interval(11, 26));

		foreach(KeyValuePair<string, Interval> pair in store)
			Console.WriteLine("{0} = {1}", pair.Key, pair.Value);

		Console.Write("Key: ");
		string key = Console.ReadLine();
		if(store.ContainsKey(key))   // notice : use of containskey
		{
			Interval value = store[key];
			Console.WriteLine("Value = {0}", value);
		}
		else
		{
			Console.WriteLine("No such key!");
		}

	}
}