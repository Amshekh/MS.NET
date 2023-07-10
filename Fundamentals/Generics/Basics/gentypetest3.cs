using System;


interface IReadable<out T>  // IReadable is covariant over T which means T can be replaced by its derived type
{
	T Value{get;}
}

interface IWritable<in T> // IWritable is contravariant over T which means T can be replaced by its base type
{
	T Value{set;}
}


class IndexedValue<V> : IReadable<V>, IWritable<V>
{
	private int index;
	private static int count;

	public IndexedValue()
	{
		// index = ++IndexedValueCounter.count;
		index = ++count;
	}

	public int Index
	{
		get {return index;}
	}

	public V Value{get; set;}
}

static class Test
{
	
	private static void PrintTime(IReadable<Interval> ri)
	{
		Console.WriteLine("Time = {0}", ri.Value.GetTime());
	}

	private static void PutCurrentTime(IWritable<BigInterval> wi)
	{
		DateTime ct = DateTime.Now;
		wi.Value = new BigInterval(ct.Hour, ct.Minute, ct.Second);
	}

	public static void Main()
	{
		IndexedValue<BigInterval> a = new IndexedValue<BigInterval>();
		a.Value = new BigInterval(1, 20, 30);
		PrintTime(a);
		
		IndexedValue<Interval> b = new IndexedValue<Interval>();
		PutCurrentTime(b);
		PrintTime(b);
	}
}


/* apple is a fruit

but basket of apple is to exhibit property of basket of fruit only when apple is only 
taken outside the basket and no fruit is added to apple of basket(eg. mango added then it will no more be basket of apples.) 

