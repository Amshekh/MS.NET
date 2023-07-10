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

		public virtual double GetNetIncome() // like c++ we need virtual keyword in c# for Polymorphism
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

		public override double GetNetIncome() // use override b/c c# compiler requires new or override.
		{
			double income = base.GetNetIncome();

			if(sales >= 25000)
				income += 0.05 * sales;

			return income;
		}
	}
}




// in this we have right o/p and tax for jill is generated.

/* steps for execution

1 csc /t:library payroll3.cs

2 csc basicooptest1.cs /r:payroll3.dll

3 basicooptest1.exe

*/










