using System;
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
				buffer[i] = (byte) (buffer[i] ^ '#'); // cast into byte.
			target.Write(buffer, 0, n);
		}
	}

	public static void Main(string[] args)
	{
		FileStream fin = new FileStream(args[0], FileMode.Open);
		FileStream fout = new FileStream(args[1], FileMode.CreateNew);

		Encode(fin, fout);

		fout.Close();
		fin.Close();
	}
}


/* 
csc fileiotest1.cs
np data1.txt(write some content)
fileiotest1.exe data1.txt data2.txt
data2.txt wil now contain encrypted data.
*/