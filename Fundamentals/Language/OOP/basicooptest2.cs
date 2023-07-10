using Payroll;
using System;

static class Test
{
	private static double GetAverageIncome(Employee[] group)
	{
		double total = 0;

		foreach(Employee emp in group) // we have foreach loop just as in java
		{
			total += emp.GetNetIncome();
		}

		return total / group.Length;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double total = 0;

		foreach(Employee emp in group)   // notice: use of "in" operator in c#.
		{
			SalesPerson sp = emp as SalesPerson; // "as" is another operator in c#. here each employee is treated as salesperson.
			if(sp != null)
				total += sp.Sales;
		}

		return total;
	}

	private static double GetAverageBonus(Employee[] group)
	{
		double total = 0;

		foreach(Employee emp in group)
		{
			if(emp is SalesPerson)
				total += 0.15 * emp.GetNetIncome();
			else
				total += 0.25 * emp.GetNetIncome();
		}

		return total / group.Length;
	}

	public static void Main()
	{
		Employee[] dept = 
		{
			new Employee(200, 250),
			new Employee(183, 52),
			new SalesPerson(175, 51, 60000),
			new Employee(190, 63),
			new SalesPerson(185, 55, 40000)
		};

		Console.WriteLine("Average Income: {0:0.00}", GetAverageIncome(dept));
		Console.WriteLine("Total Sales: {0:0.00}", GetTotalSales(dept));
		Console.WriteLine("Average Bonus: {0:0.00}", GetAverageBonus(dept));
	}
}













