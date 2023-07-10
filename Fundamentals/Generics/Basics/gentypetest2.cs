using System;

class IndexedValueCounter
{
	internal static int count = 0;
} 

class IndexedValue<V>
{
	private int index;
	

	public IndexedValue()
	{
		index = ++IndexedValueCounter.count;
		
	}

	public int Index
	{
		get {return index;}
	}

	public V Value{get; set;}

	public void CopyValue<U>(IndexedValue<U> source) where U : V
	{
		this.Value = source.Value;
	}
}

static class Test
{

	// Extension Method
	private static void Print<T>(this IndexedValue<T> iv)
	{
		Console.WriteLine("IndexedValue[{0}] = {1}", iv.Index, iv.Value);
	}	

	public static void Main()
	{
		IndexedValue<string> a = new IndexedValue<string>();
		a.Value = "Monday";
		Print(a);
		
		IndexedValue<string> b = new IndexedValue<string>{Value="Tuesday"};
		b.Print();

		IndexedValue<double> c = new IndexedValue<double>{Value=11.11};
		c.Print();

		IndexedValue<BigInterval> d = new IndexedValue<BigInterval>();
		d.Value = new BigInterval(2, 30, 40);
		d.Print();

		IndexedValue<Interval> e = new IndexedValue<Interval>();
		e.CopyValue(d);
		e.Print();
	}
}