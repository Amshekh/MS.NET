using System;

class IndexedValueCounter
{
	internal static int count = 0;
} 

class IndexedValue<V>
{
	private int index;
	//private static int count;

	public IndexedValue()
	{
		index = ++IndexedValueCounter.count;
		//index = ++count;
	}

	public int Index
	{
		get {return index;}
	}

	public V Value{get; set;}
}

static class Test
{

	public static void Main()
	{
		IndexedValue<string> a = new IndexedValue<string>();
		a.Value = "Monday";
		Console.WriteLine("IndexedValue[{0}] = {1}", a.Index, a.Value);
		
		IndexedValue<string> b = new IndexedValue<string>{Value="Tuesday"};
		Console.WriteLine("IndexedValue[{0}] = {1}", b.Index, b.Value);

		IndexedValue<double> c = new IndexedValue<double>{Value=11.11};
		Console.WriteLine("IndexedValue[{0}] = {1}", c.Index, c.Value);

		IndexedValue<Interval> d = new IndexedValue<Interval>();
		d.Value = new BigInterval(2, 30, 40);
		Console.WriteLine("IndexedValue[{0}] = {1}", d.Index, d.Value);
	}
}