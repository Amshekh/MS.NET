using System;
using System.IO;
using System.IO.MemoryMappedFiles;

static class Test
{
	private static void RunAsWriter(string text)
	{
		using(MemoryMappedFile mapping = MemoryMappedFile.CreateNew("testshm", 4096))
		{
			using(MemoryMappedViewStream view = mapping.CreateViewStream())
			{
				StreamWriter writer = new StreamWriter(view);
				writer.WriteLine(text);
				writer.Close();
			}
			
			Console.WriteLine("Text shared, please enter any key to exit....");
			Console.ReadLine();
		}
	}

	private static void RunAsReader()
	{
		using(MemoryMappedFile mapping = MemoryMappedFile.OpenExisting("testshm"))
		{
			using(MemoryMappedViewStream view = mapping.CreateViewStream())
			{
				StreamReader reader = new StreamReader(view);
				Console.WriteLine("shared text : {0}", reader.ReadLine());
				reader.Close();
			}
		}
	}
	
	public static void Main(string[] args)
	{
		if(args.Length > 0)
			RunAsWriter(args[0]);
		else
			RunAsReader();
	}
}

/*
both reader as well as writer required only then sharing of text takes place.
*/