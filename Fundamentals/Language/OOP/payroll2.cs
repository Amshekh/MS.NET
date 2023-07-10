namespace Payroll
{
	public class Employee
	{
		private int id;
		internal int hours;
		protected float rate;
		static int count;

		public Employee(int h, float r)
		{
			id = 101 + count++;
			hours = h;
			rate = r;
		}
		
		public Employee() : this(0, 50)
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

		public virtual double GetNetIncome()
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

		public new double GetNetIncome()  // here a new function name GetNetIncome get's created and thus not override so no polymorphism and is entirely a new function.
		{
			double income = base.GetNetIncome();

			if(sales >= 25000)
				income += 0.05 * sales;

			return income;
		}
	}
}




// in this we don't have right o/p b/c tax for jill is not generated.












