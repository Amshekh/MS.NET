using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Test
{
	private static void RunAsServer()
	{
		IPEndPoint local = new IPEndPoint(IPAddress.Any, 2055);
		
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		server.Bind(local);
		
		for(;;)
		{
			EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
			byte[] data = new byte[80];
			int n = server.ReceiveFrom(data, ref remote);
			for(int i = 0; i < n; i++)
				data[i] = (byte) (data[i] ^ '#');
			server.SendTo(data, remote);
		}
	}

	private static void RunAsClient(string text, string host)
	{
		IPHostEntry entry = Dns.GetHostEntry(host);
		IPAddress addr = Array.Find(entry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
	
		IPEndPoint remote = new IPEndPoint(addr, 2055);

		Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		
		byte[] request = Encoding.ASCII.GetBytes(text);
		client.SendTo(request, remote);
		byte[] response = new byte[80];
		int n = client.Receive(response);
		Console.WriteLine(Encoding.ASCII.GetString(response, 0, n));

		client.Close();
	}

	public static void Main(string[] args)
	{
		if(args.Length < 2)
			RunAsServer();
		else
			RunAsClient(args[0], args[1]);
	}
}














