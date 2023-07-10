namespace Payroll
{
	public class Employee
	{
		private int id;
		internal int hours;
		protected float rate;
		static int count;	// here static is not acess modifier.bydefault modifiers are private in c#.

		public Employee(int h, float r)
		{
			id = 101 + count++;
			hours = h;
			rate = r;
		}
		
		public Employee() : this(0, 50) // like java we do not have extends or implements in c#. in c# we have ":"
		{
		}
		
		public int Hours
		{
			get
			{
				return hours;
			}
			set
			{
				hours = value;
			}
		}

		public float Rate
		{
			get {return rate;}
			set {rate = value;}
		}

		public int Id
		{
			get {return id;}
		}

		public double GetNetIncome()
		{
			double income = hours * rate;
			int ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		public static int CountEmployees()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		private double sales;
		
		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			sales = s;
		}

		public double Sales
		{
			get {return sales;}
			set {sales = value;}
		}

		public new double GetNetIncome() // advantage of having new is that we can have 2 functions with same name
		{
			double income = base.GetNetIncome();

			if(sales >= 25000)
				income += 0.05 * sales;

			return income;
		}
	}
}



// in this we don't have right o/p b/c tax for jill is not generated.













