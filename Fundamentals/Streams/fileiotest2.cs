using System;
using System.IO;

static class Test
{
	private static void Reverse(byte[] bytes)
	{
		for(int i = 0, j = bytes.Length - 1; i < j; i++, j-- )
		{
			byte ib = bytes[i];
			byte jb = bytes[j];

			bytes[i] = jb;
			bytes[j] = ib;
		}
	}

	public static void Main(string[] args)
	{
		FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.ReadWrite);
		byte[] buffer = new byte[(int) fs.Length]; 

		fs.Read(buffer, 0, buffer.Length);
		Reverse(buffer);
		fs.Position = 0;
		fs.Write(buffer, 0, buffer.Length);
		fs.Close();
	}
}

/*
csc fileiotest2.cs
fileiotest2.exe data1.txt
*/