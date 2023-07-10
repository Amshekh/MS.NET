using System;
using System.Linq;
using System.Collections.Generic;

class Employee
{
	public string Name{get; set;}
		
	public int Experience{get; set;}

	public double Salary{get; set;}
}

static class Test
{
	public static void Main()
	{
		ICollection<Interval> store = new LinkedList<Interval>();
		store.Add(new Interval(12, 51));
		store.Add(new Interval(14, 42));
		store.Add(new Interval(16, 33));
		store.Add(new BigInterval(1, 15, 24));
		store.Add(new Interval(13, 15));

		Console.WriteLine("All intervals");
		foreach(Interval i in store)
			Console.WriteLine("{0}\t{1}", i, i.GetTime());

		var result1 = from i in store where i.Minutes > 13 select i.GetTime(); 
			      // store.Where(i => i.Minutes > 13).Select(i => i.GetTime())
		Console.WriteLine("Times in selected intervals");
		foreach(var t in result1)
			Console.WriteLine(t);

		List<Employee> dept = new List<Employee>
		{
			new Employee{Name="Jack", Experience=4, Salary=45000},
			new Employee{Name="Jill", Experience=3, Salary=35000},
			new Employee{Name="Jeff", Experience=2, Salary=25000},
			new Employee{Name="Jane", Experience=7, Salary=75000},
			new Employee{Name="Jerry", Experience=5, Salary=15000}
		};

		var result2 = from e in dept   // here e refers to employee.
			      where e.Experience > 3
			      orderby e.Salary descending
			      select new{Id=e.Name.ToUpper(), Income=0.85 * e.Salary}; 
		Console.WriteLine("Incomes of experienced employees");
		foreach(var e in result2)
			Console.WriteLine("{0}\t{1:0.00}", e.Id, e.Income);
	}
}

/* LINQ EXAMPLE FOR THE CASE WHEN DATA SOURCE IS OBJECT COLLECTION.

HERE WE HAVE NO OTHER OPTION BUT TO DO EXPLICITLY.*/


