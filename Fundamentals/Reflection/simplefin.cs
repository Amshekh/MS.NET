using System;

namespace Finance
{
	
	public interface ILoanPolicy
	{

		float InterestRate(double amount, int period);

	}

	public class HomeLoan : ILoanPolicy
	{

		public float InterestRate(double amount, int period)
		{
			return (period < 5) ? 7 : 8;
		}

	}

	public class EducationLoan : ILoanPolicy
	{

		public float InterestRate(double amount, int period)
		{
			return 6;
		}

	}

	public class PersonalLoan : ILoanPolicy
	{

		public float InterestRate(double amount, int period)
		{
			return (amount < 50000) ? 8 : 9;
		}

		public float EmployeeInterestRate(double amount, int period)
		{
			return (amount < 75000) ? 4 : 5;
		}
	}

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
