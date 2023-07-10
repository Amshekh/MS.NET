using System;

static class Client
{
	public static void Main(string[] args)
	{
		string name = args[0];
		int age = Convert.ToInt32(args[1]);

		GreeterService client = new GreeterService();
		
		GreetInfo info = client.Meet(name, age);
		Console.WriteLine("{0}, Time on server is {1}", info.Message, info.Time);

		Console.WriteLine(client.Leave(name));
	}
}