using System;
using System.IO;
using System.IO.Pipes;

static class Test
{
	private static void RunAsProducer(int count)
	{
		using(NamedPipeServerStream server = new NamedPipeServerStream("testpipe", PipeDirection.Out))
		{
			server.WaitForConnection();

			BinaryWriter writer = new BinaryWriter(server);
			for(int i = count; i >= 0; i--)
			{
				Worker.DoWork(100 * i + 10);
				writer.Write(i);
				writer.Flush();
			}
			writer.Close();
		}
	}

	private static void RunAsConsumer()
	{
		using(NamedPipeClientStream client = new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
		{
			client.Connect();

			BinaryReader reader = new BinaryReader(client);
			int value;
			do
			{
				value = reader.ReadInt32();
				Console.WriteLine("Processed value = {0}", value * value * value);
			}
			while(value != 0);
			reader.Close();
		}
	}
	
	public static void Main(string[] args)
	{
		if(args.Length > 0)
			RunAsProducer(Convert.ToInt32(args[0]));
		else
			RunAsConsumer();
	}
}

/* in case of named pipe the advantage is that any one i.e. either of client or server can start

open another command prompt, if we do not pass argument it will run as consumer

and if we pass arguments then it will run as producer */