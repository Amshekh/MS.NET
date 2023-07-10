using System;
using System.Threading;

class JointAccount
{
	private int id;
	private int balance;
	private static int nextId = 1000;

	public JointAccount()
	{
		id = ++nextId;     // id will be generated when required i.e. irrespective of thread numbering id will be generated when required.
		balance = 10000;
	}

	public int Id
	{
		get {return id;}
	}

	public int Balance
	{
		get {return balance;}
	}

	public void Deposit(int amount)
	{
		balance += amount;
	}

	public bool Withdraw(int amount)
	{
		bool result = false;
		
		if(balance >= amount)
		{
			Worker.DoWork(amount / 10);
			balance -= amount;
			result = true;
		}
		
		return result;
	}
}

static class Test
{
	public static void Main()
	{
		JointAccount acc = new JointAccount();

		Console.WriteLine("Joint-Account with ID {0} opened for John and Jeff", acc.Id);
		Console.WriteLine("Initial balance: {0}", acc.Balance);

		Thread th = new Thread(delegate()
		{
			Console.WriteLine("Jeff withdraws 7000 from Joint-Account...");
			if(!acc.Withdraw(7000))
				Console.WriteLine("Jeff's withdraw operation failed!");
		});

		th.Start();

		Console.WriteLine("John withdraws 6000 from joint-Account...");
		if(!acc.Withdraw(6000))
			Console.WriteLine("John's withdraw operation failed!");

		th.Join();

		Console.WriteLine("Final balance: {0}", acc.Balance);
	}
}

// In this both transaction takes place and bank looses money.