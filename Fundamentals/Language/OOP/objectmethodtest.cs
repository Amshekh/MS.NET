using System;

partial class Interval
{
	public Interval Add(Interval other)
	{
		return new Interval(minutes + other.minutes, seconds + other.seconds);
	}
}

static class Test
{
	public static void Main()
	{
		Interval a = new Interval(5, 15);
		Interval b = new Interval(6, 50);
		Interval c = new Interval(3, 135);
		Interval d = b;
		
		Console.WriteLine("a => {0}", a);
		Console.WriteLine("b => {0}", b);
		Console.WriteLine("c => {0}", c);
		Console.WriteLine("d => {0}", d);

		Console.WriteLine("a is identical to b: {0}", object.ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", object.ReferenceEquals(a, c));
		Console.WriteLine("b is identical to d: {0}", object.ReferenceEquals(b, d));

		Console.WriteLine("Hash-code of a = {0}", a.GetHashCode());
		Console.WriteLine("Hash-code of b = {0}", b.GetHashCode());
		Console.WriteLine("Hash-code of c = {0}", c.GetHashCode());
		Console.WriteLine("Hash-code of d = {0}", d.GetHashCode());

		Console.WriteLine("a is equal to b: {0}", a.Equals(b));
		Console.WriteLine("a is equal to c: {0}", a.Equals(c));
		Console.WriteLine("b is equal to d: {0}", b.Equals(d));
	
		Console.WriteLine("a + b => {0}", a.Add(b));
	}
}


// see the difference b/w identical and equals in your o/p.











