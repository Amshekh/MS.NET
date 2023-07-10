using System;
using System.IO;
using System.IO.MemoryMappedFiles;

static class Test
{
	
	public static void Main(string[] args)
	{
		FileInfo file = new FileInfo(args[0]); // file info contains all information about file other than its contents.

		using(MemoryMappedFile mapping = MemoryMappedFile.CreateFromFile(file.FullName))
		{
			using(MemoryMappedViewAccessor view = mapping.CreateViewAccessor(0, file.Length))
			{
				for(long i = 0, j = view.Capacity - 1; i < j; i++, j--)
				{
					byte ib = view.ReadByte(i);
					byte jb = view.ReadByte(j);

					view.Write(i, jb);
					view.Write(j, ib);

				}
			}
		}
	}
}

/*
we can reverse the contents of file in memory. it is faster.

*/