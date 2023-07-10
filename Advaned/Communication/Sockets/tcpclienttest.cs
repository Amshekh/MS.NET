using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

static class Test
{
	public static void Main(string[] args)
	{
		TcpClient client = new TcpClient(args[1], 2056);
		Stream s = client.GetStream();
		StreamReader reader = new StreamReader(s);
		StreamWriter writer = new StreamWriter(s);

		Console.WriteLine(reader.ReadLine());
		writer.WriteLine(args[0]);
		writer.Flush();
		Console.WriteLine(reader.ReadLine());

		writer.Close();
		reader.Close();
		client.Close();
 	}
}
/*
compile tcpclienttest.cs

start server as this is client prg and we need server : start tcplistener2.exe

telnet localhost 2056

tcpclienttest.exe companyname localhost
*/