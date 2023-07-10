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

			StreamWriter writer = new StreamWriter(new FileStream("product.txt", FileMode.Create));
			writer.WriteLine(price);
			writer.WriteLine(stock);
			writer.WriteLine(name);
			writer.Close();
		}
		else
		{
			StreamReader reader = new StreamReader(new FileStream("product.txt", FileMode.Open));
			float price = Convert.ToSingle(reader.ReadLine());
			short stock = Convert.ToInt16(reader.ReadLine());
			string name = reader.ReadLine();
			reader.Close();

			Console.WriteLine("{0} {1} {2}", name, stock, price);
		}
	}
}

