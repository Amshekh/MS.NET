using System;

partial class Interval
{
	public static Interval operator+(Interval first, Interval second)
	{
		return new Interval(first.minutes + second.minutes, first.seconds + second.seconds);
	}
	
	public static Interval operator++(Interval target)
	{
		return new Interval(target.minutes, target.seconds + 1); // here second will be incremented by one 
	}

	public static bool operator<(Interval first, Interval second)
	{
		return first.GetTime() < second.GetTime();
	}
	
	public static bool operator>(Interval first, Interval second)
	{
		return first.GetTime() > second.GetTime();
	}

	public static bool operator==(Interval first, Interval second)
	{
		return first.Equals(second);
	}

	public static bool operator!=(Interval first, Interval second)
	{
		return !first.Equals(second);
	}

	public static implicit operator Interval(double value)
	{
		int m = (int) value;
		int s = (int) (60 * (value - m));

		return new Interval(m, s);
	}

	public static explicit operator double(Interval value)
	{
		return value.minutes + value.seconds / 60.0;  // here 60.0 b/c of double otherwise it will result to zero as then it will be int type.
	}
	
	public int this[int index]
	{
		get
		{
			if(index == 0)
				return seconds;

			return minutes;
		}
	}
}

static class Test
{
	public static void Main()
	{
		Interval a = new Interval(7, 30);
		Console.WriteLine("a => {0}", a);

		Interval b = new Interval(3, 45);
		Console.WriteLine("b => {0}", b);

		Interval c = a + b;  // Interval.op_Addition(a, b); we do not have to write this directly
		Console.WriteLine("c => {0}", c);

		Interval d = ++c;  // c = Interval.op_Increment(c);d = c; preincrement so first increment is done and then assigned.
		Console.WriteLine("c => {0}", c);
		Console.WriteLine("d => {0}", d);

		Interval e = d++; // e = d; d = Interval.op_Increment(d); 
		Console.WriteLine("d => {0}", d);
		Console.WriteLine("e => {0}", e);

		Interval f = 7.25; // here 7.25 means 7 and quarter i.e 7 mins and 15 seconds
		Console.WriteLine("f => {0}", f);
		
		double g = (double) f;
		Console.WriteLine("g => {0}", g);

		Console.WriteLine("Interval a has {0} minutes and {1} seconds.", a[10], a[0]);
		Console.WriteLine("Interval b has {0} minutes and {1} seconds.", b[10], b[0]);
	}
}