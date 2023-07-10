using System;
using System.IO;
using System.Net;

static class Test
{
	public static void Main(string[] args)
	{
		string url = string.Format("http://{0}:8055/stock?symbol={1}", args[1], args[0]);
		WebClient client = new WebClient();
		Stream s = client.OpenRead(url);
		StreamReader reader = new StreamReader(s);

		Console.WriteLine(reader.ReadLine());

		reader.Close();
	}
}
