using System;
using System.Threading;

class JointAccount
{
	private int id;
	private int balance;
	private static int nextId = 1000;

	public JointAccount()
	{
		id = Interlocked.Increment(ref nextId);
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

	public void Deposit(int amount) // here read and write both operations take place so lock
	{
		lock(this)
			balance += amount;
	}

	public bool Withdraw(int amount) // here read and write both operations take place so lock
	{
		bool result = false;
		

		lock(this)
		{		
			if(balance >= amount)
			{
				Worker.DoWork(amount / 10);
				balance -= amount;
				result = true;
			}
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



