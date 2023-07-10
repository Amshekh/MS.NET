using System;
using System.Collections.Generic;

namespace HR
{
	[Serializable]
	public class Employee
	{
		private string code;
		private string password;
		private int experience;
		private double salary;

		public string Code
		{
			get{return code;}
			set{code = value;}
		}

		public string Password
		{
			get{return password;}
			set{password = value;}
		}

		public int Experience
		{
			get{return experience;}
			set{experience = value;}
		}

		public double Salary
		{
			get{return salary;}
			set{salary = value;}
		}

		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}\t{3}", code, password, experience, salary);
		}		
	}

	[Serializable]
	public class Department
	{
		private string title = null;
		private List<Employee> employees = new List<Employee>();

		public string Title
		{
			get{return title;}
			set{title = value;}
		}

		public List<Employee> Employees
		{
			get{return employees;}
			set{employees = value;}
		}

		public Employee AddEmployee(int exp, double sal){
			Employee emp = new Employee();
			int i = 501 + employees.Count;

			emp.Code = title.Substring(0, 3).ToUpper() + i;
			emp.Password = "PWD" + i;
			emp.Experience = exp;
			emp.Salary = sal;
			employees.Add(emp);

			return emp;
		}

	}

}

















