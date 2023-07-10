using System;
using System.Linq;
using System.Xml.Linq;

static class Test
{
	public static void Main()
	{
		XElement dept = XElement.Load("dept.xml");
		var result = from e in dept.Element("Employees") .Elements("Employee")
			where (int) e.Element("Experience") > 3  // here experience is cast from some element type to int.
			select new {Id = (string) e.Attribute("Code"), Income=0.85 * ((double) e.Element("Salary"))}; // here attribute code is cast to string type, salary to double type.

		foreach(var entry in result)
			Console.WriteLine("{0} \t{1}", entry.Id, entry.Income);
	}
}

/*
it is not good practice to pass object b/c then you will have to give class to java prgmr.
so we should use schema(it's good practice)

csc xlinqtest.cs
xlinqtest.exe

we get id and net income of employees with experience greater than 3.
*/