using System;
using System.Text;
using System.IO;

static class Test
{
	private static void Encode(Stream source, Stream target)
	{
		byte[] buffer = new byte[80];

		while(source.Position < source.Length)
		{
			int n = source.Read(buffer, 0, buffer.Length);
			for(int i = 0; i < n; i++)
				buffer[i] = (byte) (buffer[i] ^ '#');
			target.Write(buffer, 0, n);
		}
	}

	public static void Main(string[] args)
	{
		byte[] odata = Encoding.UTF8.GetBytes(args[0]);
		MemoryStream min = new MemoryStream(odata);
		MemoryStream mout = new MemoryStream(odata.Length);

		Encode(min, mout);

		byte[] edata = mout.ToArray();
		string text = Encoding.UTF8.GetString(edata);
		Console.WriteLine(text);
	}
	
}

/* it is faster compared to one we do in files as i this case we do in memory */