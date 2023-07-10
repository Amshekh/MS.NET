using System;

class IndexedValue : IDisposable
{
	private int index;
	private static int count;

	static IndexedValue()
	{
		#if(_TESTING)
		Console.WriteLine("--IndexedValue type initialized.");
		#endif
	}

	public IndexedValue()
	{
		index = ++count;
		
		#if(_TESTING) 
		Console.WriteLine("--IndexedValue instance<{0}> initialized.", index);
		#endif
	}

	public int Index
	{
		get {return index;}
	}
	
	public double Value{get; set;}

	public void Dispose()
	{
		#if(_TESTING) 
		Console.WriteLine("--IndexedValue instance<{0}> disposed.", index);
		#endif

		GC.SuppressFinalize(this); // inorder to stop double close i.e. closing something which is already closed.
	}

	~IndexedValue()
	{
		#if(_TESTING) 
		Console.WriteLine("--IndexedValue instance<{0}> finalized.", index);
		#endif

	}
}

static class Test
{
	public static void Main(string[] args)
	{
		IndexedValue a = new IndexedValue();
		a.Value = 12.34;
		Console.WriteLine("a:{0} = {1}", a.Index, a.Value);

		IndexedValue b = new IndexedValue{Value=23.45};
		Console.WriteLine("b:{0} = {1}", b.Index, b.Value);

		b = null;
		Console.WriteLine("Before garbage-collection IndexedValue<{0}> is in generation:{1}", a.Index, GC.GetGeneration(a));
		GC.Collect();
		Console.WriteLine("After garbage-collection IndexedValue<{0}> is in generation:{1}", a.Index, GC.GetGeneration(a));

		IndexedValue c = new IndexedValue{Value=34.56};
		Console.WriteLine("c:{0} = {1}", c.Index, c.Value);
		c.Dispose();

		using(IndexedValue d = new IndexedValue())
		{
			d.Value = args.Length == 0 ? 45.67 : Convert.ToDouble(args[0]);
			Console.WriteLine("d:{0} = {1}", d.Index, d.Value);
		}
		
		Console.WriteLine("Enter any key to exit...");
		Console.ReadLine();
	}
}



// whenever we use use using keyword in c# dispose operation is done by the cs compiler and in this way resource leaking is avoided.





























