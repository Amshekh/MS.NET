using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

static class Test
{
	private static string[] symbols = {"DELL", "GOGL", "INTC", "MSFT", "ORCL"};
	private static Random rnd = new Random();

	public static void Main()
	{
		TcpListener listener = new TcpListener(IPAddress.Any, 2056);
		listener.Start();

		Service(listener);
	}

	private static void Service(TcpListener server)
	{
		for(;;)
		{
			TcpClient client = server.AcceptTcpClient();
			client.ReceiveTimeout = 12000;

			Stream s = client.GetStream();
			StreamReader reader = new StreamReader(s);
			StreamWriter writer = new StreamWriter(s);
			writer.AutoFlush = true;
			
			try
			{
				writer.WriteLine("Welcome to stock-server.");
				string symbol = reader.ReadLine();
				int i = Array.IndexOf(symbols, symbol);
				if(i >= 0)
					writer.WriteLine("Price is {0:0.00}", rnd.Next(1000, 10000) / 100.0);
				else
					writer.WriteLine("Price not available!");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			writer.Close();
			reader.Close();
			client.Close();
		}
	}
}


/*
compile prg as usual: csc filename
in another cmd prmt start exe file : start tcplistenertest1.exe
telnet localhost 2056
enter required share and we get o/p 
share price is generated b/w 10 and 999 randomly for comp. mentioned in code

*/










