using System;
using System.Net;

static class Test
{

	public static void Main(string[] args)
	{
		string host = args.Length > 0 ? args[0] : Dns.GetHostName();

		try
		{
			IPHostEntry entry = Dns.GetHostEntry(host);
			foreach(IPAddress addr in entry.AddressList)
				Console.WriteLine("{0} / {1}", host, addr);

		}
		catch
		{
			Console.WriteLine("Cannot resolve host-name!");
		}
	}
}

/*
to show ip addr v4 of a given computer.

in this case for. e.g. dnstest.exe adsd26
*/