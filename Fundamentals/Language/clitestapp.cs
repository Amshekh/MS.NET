using Greeting;
using System;

static class App
{
	public static void Main()
	{
		Greeter g = new Greeter();
		
		Console.WriteLine(g.Greet("Jeff", 90));
		Console.WriteLine(g.Greet("Lionardo", 15));
	}
}