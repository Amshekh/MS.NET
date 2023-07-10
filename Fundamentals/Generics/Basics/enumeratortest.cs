using System;
using System.Collections.Generic;

class LottoStateMachine
{
	private int digits;
	private static Random rnd = new Random();

	public LottoStateMachine(int digits)
	{

		this.digits = digits;
	}

	private static int GetNextDigit()
	{
		int t = Environment.TickCount + 1000;
		while(Environment.TickCount < t);

		return rnd.Next(0, 10);
	}

	public IEnumerator<int> GetEnumerator()
	{
		for(int i = 0; i < digits; i++)
			yield return GetNextDigit();
	}
}

static class Test
{
	public static void Main()
	{
		LottoStateMachine lotto = new LottoStateMachine(10);
			
		Console.Write("Winner:");
		foreach(int digit in lotto)
			Console.Write(" {0}", digit);
		Console.WriteLine("!");
	}
}