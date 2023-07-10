using System;
using System.IO;
using System.Net;

static class Test
{
	private static string[] symbols = {"DELL", "GOGL", "INTC", "MSFT", "ORCL"};
	private static Random rnd = new Random();

	public static void Main()
	{
		HttpListener server = new HttpListener();
		server.Prefixes.Add("http://*:8055/stock/");
		server.Start();

		for(;;)
		{
			HttpListenerContext client = server.GetContext();
			string symbol = client.Request.QueryString["symbol"];

			client.Response.ContentType = "text/plain";
			StreamWriter writer = new StreamWriter(client.Response.OutputStream);

			int i = Array.IndexOf(symbols, symbol);
			if(i >= 0)
				writer.WriteLine("Price is {0:0.00}", rnd.Next(1000, 10000) / 100.0);
			else
				writer.WriteLine("Price not available!");

			writer.Close();
		}
	}
}












