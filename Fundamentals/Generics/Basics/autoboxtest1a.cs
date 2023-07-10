using System;

static class Test
{

	public static void Main(string[] args)
	{
		double a = 12.25;
		object b = a;
		
	}
}

/* do ildasm it's exe and see main content.double is value type and object is reference type.
	cs compiler does autoboxing to get necesary conversion. */