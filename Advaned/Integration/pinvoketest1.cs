using System;
using System.Text;
using System.Runtime.InteropServices;

static class Test
{
	
	[DllImport("legacy\\strenc", EntryPoint="HashOfBuffer", CallingConvention = CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
	private extern static int GetBufferHash(string str, int sz);	

	[DllImport("legacy\\strenc", CallingConvention=CallingConvention.Cdecl)]
	private extern static int EncodeString(string src, int sz, StringBuilder dst);

	public static void Main(string[] args)
	{
		Console.WriteLine("Original text: {0}", (args[0]));

		int n = args[0].Length;
		Console.WriteLine("Hash of Text: {0:X}", GetBufferHash(args[0], n));// X for hexadecimal value

		StringBuilder sb = new StringBuilder(n - 1);
		EncodeString(args[0], n, sb);
		Console.WriteLine("Encoded text: {0}", sb.ToString());
	}
}