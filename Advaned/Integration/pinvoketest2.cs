using System;
using System.Runtime.InteropServices;

static class Test
{
	[StructLayout(LayoutKind.Sequential)]
	struct FixedDeposit
	{
		public int Id;
		public double Amount;
		public int Period;
	}

	[DllImport("legacy\\invest")]
	private extern static int InitFixedDeposit(double amount, int period, out FixedDeposit fd);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	delegate float Scheme(double amount, int period);

	[DllImport("legacy\\invest")]
	private extern static double GetMaturityValue(ref FixedDeposit fd, Scheme policy);
	
	public static float WelfareScheme(double p, int n)
	{
		return p < 50000 ? 9.25f : 9.50f;	
	}

	public static void Main(String[] args)
	{
		double p = Convert.ToDouble(args[0]);
		int n = Convert.ToInt32(args[1]);
		FixedDeposit fd;

		InitFixedDeposit(p, n, out fd); // fd is out type.
		Console.WriteLine("New fixed-deposit ID: {0}", fd.Id);

		Console.WriteLine("Final cash-value: {0:0.00}", GetMaturityValue(ref fd, WelfareScheme));
	}
}