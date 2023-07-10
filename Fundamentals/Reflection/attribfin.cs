using System;

namespace Finance
{
	
	[AttributeUsage(AttributeTargets.Class)]
	public class ReducingBalanceAttribute : Attribute{}

	[AttributeUsage(AttributeTargets.Method)]
	public class MaxDurationAttribute : Attribute
	{
		private int limit;

		public MaxDurationAttribute(int value)
		{
			limit = value;
		}
		
		public MaxDurationAttribute() : this(5){}

		public int Limit
		{
			get {return limit;}
			set {limit = value;}
		}
	}
	
	public interface ILoanPolicy
	{

		float InterestRate(double amount, int period);

	}
	
	[ReducingBalance]
	public class HomeLoan : ILoanPolicy
	{
		[MaxDuration(12)]
		public float InterestRate(double amount, int period)
		{
			return (period < 5) ? 7 : 8;
		}

	}

	public class EducationLoan : ILoanPolicy
	{
		[MaxDuration]
		public float InterestRate(double amount, int period)
		{
			return 6;
		}

	}

	[ReducingBalance]
	public class PersonalLoan : ILoanPolicy
	{
		
		[MaxDuration(Limit=4)]
		public float InterestRate(double amount, int period)
		{
			return (amount < 50000) ? 8 : 9;
		}

		public float EmployeeInterestRate(double amount, int period)
		{
			return (amount < 75000) ? 4 : 5;
		}
	}

	[Serializable]
	public class BusinessLoan
	{
		
		public float RateOfInterest(double amount, int period)
		{
			float r = (amount < 100000) ? 9 : 10;
			if(period > 2) r += 1;
			return r;
		}

	}

}


// attribute are to be coded in square brackets.