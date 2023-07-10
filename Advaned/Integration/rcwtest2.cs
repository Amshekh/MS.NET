using QuadEq;
using System;
using System.Runtime.InteropServices;


static class Test
{
	[STAThread]
	public static void Main(string[] args)
	{
		double a = Convert.ToDouble(args[0]);
		double b = Convert.ToDouble(args[1]);
		double c = Convert.ToDouble(args[2]);

		//IEquation eqn = (IEquation) new QuadraticEquationClass();
		QuadraticEquationClass eqn = new QuadraticEquationClass();

		if(eqn.HasRealRoots(a, b, c) != 0)
		{
			double r1, r2;
			eqn.Solve(a, b, c, out r1, out r2);
			Console.WriteLine("Roots = ({0}, {1})", r1, r2);
		}
		else
			Console.WriteLine("No real roots!");
	}
}

/*
	import type library and then compile using the required dll
	fially execute the program by passing values.
*/