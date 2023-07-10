using Finance;
using System;
using System.Reflection;

static class Test
{

	public static void Main(string[] args)
	{
		double p = Convert.ToDouble(args[0]);
		Type t = Type.GetType(args[1], true);
		ILoanPolicy pol = (ILoanPolicy) Activator.CreateInstance(t);
		int m = 10;

		for(int n = 1; n <= m; n++)
		{
			float r = pol.InterestRate(p, m);
			double emi;

			emi = p * Math.Pow(1 + r / 100, n) / (12 * n);

			Console.WriteLine("{0}\t{1:0.00}", n, emi);
		}
	}
}

// Interface level.