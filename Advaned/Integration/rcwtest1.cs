using System;
using System.Runtime.InteropServices;

[Guid("B7DF16F3-095A-412C-8347-A7EB727297B8")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

interface IEquation
{
	int HasRealRoots(double a, double b, double c);
	void Solve(double a, double b, double c, out double root1, out double root2);
}

[Guid("204961C4-291C-4698-A77F-BFA2250778C6")]
[ComImport]
class QuadraticEquationClass{}

static class Test
{
	[STAThread]
	public static void Main(string[] args)
	{
		double a = Convert.ToDouble(args[0]);
		double b = Convert.ToDouble(args[1]);
		double c = Convert.ToDouble(args[2]);

		IEquation eqn = (IEquation) new QuadraticEquationClass();

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
