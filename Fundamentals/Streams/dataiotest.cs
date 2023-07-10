using System;
using System.IO;

static class Test
{
	public static void Main(string[] args)
	{
		if(args.Length > 2)
		{
			string name = args[0].ToUpper();
			short stock = Convert.ToInt16(args[1]);	
			float price = Convert.ToSingle(args[2]);

			BinaryWriter writer = new BinaryWriter(new FileStream("product.dat", FileMode.Create));
			writer.Write(price);
			writer.Write(stock);
			writer.Write(name);
			writer.Close();
		}
		else
		{
			BinaryReader reader = new BinaryReader(new FileStream("product.dat", FileMode.Open));
			float price = reader.ReadSingle();
			short stock = reader.ReadInt16();
			string name = reader.ReadString();
			reader.Close();

			Console.WriteLine("{0} {1} {2}", name, stock, price);
		}
	}
}

/*
csc dataiotest.cs
dataiotest.exe hdd 50000 4500

inside product.dat file you see your encrypted data
*/