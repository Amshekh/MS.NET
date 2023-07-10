using System;
using System.Reflection;
using System.Reflection.Emit;
using Operation = System.Func<double, double, double>;

static class Test
{
	private static Operation EmitOperation(string name)
	{
		Type[] signature = {typeof(double), typeof(double)};
		DynamicMethod dm = new DynamicMethod(name, typeof(double), signature, typeof(Test));
		ILGenerator ilg = dm.GetILGenerator();
		
		ilg.Emit(OpCodes.Ldarg_0);
		ilg.Emit(OpCodes.Ldarg_1);
		switch(name)
		{
			case "substract":
				ilg.Emit(OpCodes.Sub);
				break;
			case "multiply":
				ilg.Emit(OpCodes.Mul);
				break;
			case "divide":
				ilg.Emit(OpCodes.Div);
				break;
			default:
				ilg.Emit(OpCodes.Add);
				break;
		}
		ilg.Emit(OpCodes.Ret);

		return (Operation) dm.CreateDelegate(typeof(Operation));
	}

	public static void Main(string[] args)
	{
		Operation op = EmitOperation(args[0]);
		double first = Convert.ToDouble(args[1]);
		double second = Convert.ToDouble(args[2]);

		Console.WriteLine("Result = {0}", op(first, second));
	}
}



















