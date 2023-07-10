using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR
{
	[Serializable]
	public class Employee : ISerializable
	{
		private string code;
		private string password;
		private int experience;
		private double salary;

		public Employee() {}  // zero parameter constructor, which is required here

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

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("__code", code);
			info.AddValue("__experience", experience);
			info.AddValue("__salary", salary);
			byte[] data = Encoding.UTF8.GetBytes(password);
			for(int i = 0; i < data.Length; i++)
				data[i] = (byte) (data[i] ^ '#');
			info.AddValue("__extra", data);
		}

		private Employee(SerializationInfo info, StreamingContext context)  // this constructor is private constructor.
		{
			code = info.GetString("__code");
			experience = info.GetInt32("__experience");
			salary = info.GetDouble("__salary");
			byte[] data = (byte[]) info.GetValue("__extra", typeof(byte[]));
			for(int i = 0; i < data.Length; i++)
				data[i] = (byte) (data[i] ^ '#');
			password = Encoding.UTF8.GetString(data);			
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

















