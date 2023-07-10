using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Test
{
	public static void Main()
	{
		IPAddress addr = IPAddress.Parse("230.0.0.1");
		UdpClient subscriber = new UdpClient(2056);
		subscriber.JoinMulticastGroup(addr);

		IPEndPoint remote = null;
		for(int i = 0; i < 5; i++)
		{
			byte[] data = subscriber.Receive(ref remote);
			string text = Encoding.UTF8.GetString(data);
			Console.WriteLine(text);
		}
		
		subscriber.DropMulticastGroup(addr);
		subscriber.Close();
	}
}










