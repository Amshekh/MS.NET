using Banking;
using System;

static class Test
{
	private static double GetTotalBalance(Account[] accounts)
	{
		double total = 0;

		foreach(Account acc in accounts)
		{
			total += acc.Balance;
		}

		return total;
	}


	private static void PayAnnualInterest(Account[] accounts)
	{

		foreach(Account acc in accounts)
		{
			//SavingsAccount p = acc as SavingsAccount; (use it for banking1.dll)
			IProfitable p = acc as IProfitable;  // for banking2.dll required b/c interest to be added to any profitable a/c as after some days bank may decides to open employee a/c or other a/c's.
			if(p != null)
				p.AddInterest(1);
		}

	}
	
	// this function will not be used with banking1.dll; so when u use that comment this whole function.

	private static void DeductTax(Account[] accounts)
	{

		foreach(Account acc in accounts)
		{
			ITaxable t = acc as ITaxable;
			if(t != null)
				t.Deduct();
		}
	}

	public static void Main()
	{
		Account[] bank = new Account[4];
		bank[0] = Banker.OpenAccount(5000, true);
		bank[1] = Banker.OpenAccount(20000, false);
		bank[2] = Banker.OpenAccount(30000, false);
		bank[3] = Banker.OpenAccount(35000, true);
	
		PayAnnualInterest(bank);
		DeductTax(bank); // comment this while using with banking1.dll

		foreach(Account acc in bank)
			Console.WriteLine("{0}\t{1}", acc.Id, acc.Balance);

		Console.WriteLine("Total Balance: {0}", GetTotalBalance(bank));
	}
}















