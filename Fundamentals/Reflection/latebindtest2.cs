// using Finance;
using System;
using System.Reflection;
using RateFunc = System.Func<double, int, float>;

static class Test
{
	// delegate float RateFunc(double amount, int period);
	public static void Main(string[] args)
	{
		double p = Convert.ToDouble(args[0]);
		Type t = Type.GetType(args[1], true);
		object pol = Activator.CreateInstance(t);
		int m = 10;
		RateFunc rf = (RateFunc) Delegate.CreateDelegate(typeof(RateFunc), pol, args[2]);

		for(int n = 1; n <= m; n++)
		{
			float r = rf(p, n);
			double emi;

			emi = p * Math.Pow(1 + r / 100, n) / (12 * n);

			Console.WriteLine("{0}\t{1:0.00}", n, emi);
		}
	}
}

// One of the ways of doing late binding => using delegate