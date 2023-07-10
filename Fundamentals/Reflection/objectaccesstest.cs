using System;
using System.Reflection;

static class Test
{
	private static void PrintAsXml(object obj)
	{
		Type t = obj.GetType();

		Console.WriteLine("<{0}>", t.Name);

		foreach(PropertyInfo pi in t.GetProperties())
		{
			Console.WriteLine("  <{0}>{1}</{0}>", pi.Name, pi.GetValue(obj, null));
		}
	
		Console.WriteLine("</{0}>", t.Name);
	}

	public static void Main()
	{
		PrintAsXml(new Payroll.SalesPerson(186, 52, 75000));
		Console.WriteLine();
		PrintAsXml(DateTime.Now);
	}
}