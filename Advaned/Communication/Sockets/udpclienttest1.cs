using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Test
{
	private static string[] symbols = {"DELL", "GOGL", "INTC", "MSFT", "ORCL"};
	private static Random rnd = new Random();

	public static void Main()
	{
		UdpClient publisher = new UdpClient("230.0.0.1", 2056);
		
		for(;;)
		{
			int i = rnd.Next(0, symbols.Length);
			string text = string.Format("{0} : {1:0.00}", symbols[i], rnd.Next(1000, 10000) / 100.0);
			byte[] data = Encoding.UTF8.GetBytes(text);

			publisher.Send(data, data.Length);
			System.Threading.Thread.Sleep(10000);
		}
	}
}













