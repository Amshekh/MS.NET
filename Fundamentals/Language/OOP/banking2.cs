namespace Banking
{
	using System;

	public class InsufficientFundsException : ApplicationException{}

	public abstract class Account
	{
		internal string id = null;
		protected double balance = 0;

		public string Id
		{
			get { return id;}
		}

		public double Balance
		{
			get {return balance;}
		}
		
		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account other)
		{
			if(object.ReferenceEquals(this, other) == false)
			{
				this.Withdraw(amount);
				other.Deposit(amount);
			}
		}
	}

	public interface IProfitable
	{
		double AddInterest(int period);
	}

	public interface ITaxable
	{
		void Deduct();
	}

	public interface IFinable
	{
		void Deduct();
	}

	sealed class CurrentAccount : Account, ITaxable, IFinable // sealed class is like final class in java.
	{
		public CurrentAccount()
		{
			id = "C/A";
			balance = 0;
		}
		
		public override void Deposit(double amount)	
		{
			balance += amount;
		}

		public override void Withdraw(double amount)
		{
			balance -= amount;
		}

		void ITaxable.Deduct()
		{
			if(balance > 27000)
			{
				double tax = 0.05 * (balance - 27000);
				balance -= tax;
			}
		}

		void IFinable.Deduct()
		{
			if(balance < 0)
				balance *= 1.1;
		}
	}
	
	sealed class SavingsAccount : Account, IProfitable // sealed class is like final class in java.
	{
		// public const double MinBalance = 5000;
		public static readonly double MinBalance = 5000;


		public SavingsAccount()
		{
			id = "S/A";
			balance = MinBalance;
		}
		
		public override void Deposit(double amount)	
		{
			balance += amount;
		}

		public override void Withdraw(double amount)
		{
			if(balance - amount < MinBalance)
				throw new InsufficientFundsException();

			balance -= amount;
		}

		public double AddInterest(int period)
		{
			float rate = balance < 10000 ? 3.5f : 4.0f;
			double interest = balance * period * rate / 100;

			balance += interest;

			return interest;
		}
	}

	public static class Banker
	{
		public static int nextId = Environment.TickCount % 1000000;

		public static Account OpenAccount(double amount, bool savings=false)
		{
			Account acc;

			if(savings)
				acc = new SavingsAccount();
			else 
				acc = new CurrentAccount();
	
			acc.id += nextId++;
			acc.Deposit(amount);

			return acc;
		}
	}
}