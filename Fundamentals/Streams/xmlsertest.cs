using HR;
using System;
using System.IO;
using System.Xml.Serialization;

static class Test
{
	public static void Main(string[] args)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Department));

		if(args.Length > 0)
		{
			Department dept = new Department{Title = args[0]};
			dept.AddEmployee(3, 35000);
			dept.AddEmployee(5, 55000);
			dept.AddEmployee(6, 65000);
			dept.AddEmployee(4, 45000);
			dept.AddEmployee(2, 25000);
		
			FileStream fs = new FileStream("dept.xml", FileMode.Create); // here we will se o/p in an xm file named dept.xml
			serializer.Serialize(fs, dept);
			fs.Close();
		}
		else
		{
			FileStream fs = new FileStream("dept.xml", FileMode.Open);
			Department dept = (Department) serializer.Deserialize(fs);
			fs.Close();

			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(Employee emp in dept.Employees)
				Console.WriteLine(emp);

		}
	}
}

/* similar example to binarysertest.cs where o/p was to be written in dept.bin, here it will be 

written in dept.xml.
you will notice that it's showing password which can be hidden by editing your xmlserhr.cs

now     make dll out of this
   	compile - csc binarysertest.cs /r:xmlserhr.dll
   	xmlsertest.exe Accounting
   	output is  written to dept.xml
   	open dept.xml	
 
*/