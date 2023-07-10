using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Test
{
	
	private static void RunAsServer() // same 6 steps to be followed
	{
		IPEndPoint local = new IPEndPoint(IPAddress.Any, 2055); // IPAddress.Any i same as IPAddress.Parse("0.0.0.0")

		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		server.Bind(local);

		server.Listen(10);

		for(;;)
		{
			Socket client = server.Accept();

			byte[] data = new byte[80];
			int n = client.Receive(data);
			for(int i = 0; i < n; i++)
				data[i] = (byte) (data[i] ^ '#');
			client.Send(data);

			client.Close();
		}
	}

	private static void RunAsClient(string text, string host)
	{
		IPHostEntry entry = Dns.GetHostEntry(host);
		IPAddress addr = Array.Find(entry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

		IPEndPoint remote = new IPEndPoint(addr, 2055);

		Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		client.Connect(remote);

		byte[] request = Encoding.ASCII.GetBytes(text);
		client.Send(request);
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

/*
compile the prg. as usual : csc strmsocktest.cs
using another cmd prompt say : start strmsocktest.exe string username i.e. strmsocktest.exe amit localhost
*/