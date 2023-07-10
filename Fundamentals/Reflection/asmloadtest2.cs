using System;
using System.Reflection;

static class Test
{
	public static void Main()
	{
		for(;;)
		{
			Console.Write("CMD>");
			string cmd = Console.ReadLine();
			if(cmd == "quit") break;

			try
			{
				Assembly asm = Assembly.LoadFrom(@"commands\" + cmd + ".exe"); // if @ is not given then we have to put two slashes after commands.
				asm.EntryPoint.Invoke(null, null);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Execution failure: {0}", ex.Message);
			}

			Console.WriteLine();
		}
	}
}