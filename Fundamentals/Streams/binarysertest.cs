using HR;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // .NET provides this.

static class Test
{
	public static void Main(string[] args)
	{
		BinaryFormatter serializer = new BinaryFormatter();

		if(args.Length > 0)
		{

			Department dept = new Department{Title=args[0]};
			dept.AddEmployee(3, 35000);
			dept.AddEmployee(5, 55000);
			dept.AddEmployee(6, 65000);
			dept.AddEmployee(4, 45000);
			dept.AddEmployee(2, 25000);

			FileStream fs = new FileStream("dept.bin", FileMode.Create);
			serializer.Serialize(fs, dept);
			fs.Close();
		}
		else
		{
			FileStream fs = new FileStream("dept.bin", FileMode.Open);
			Department dept = (Department) serializer.Deserialize(fs);
			fs.Close();

			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(Employee emp in dept.Employees)
				Console.WriteLine(emp);
		}
	}
}

/* copy hr.cs to simpleserhr.cs
   make dll out of this
   compile - csc binarysertest.cs /r:simpleserhr.dll
   binarysertest.exe Accounting
   output is  written to dept.bin
   open dept.bin

the disadvantage of this prg. is that password is also shown

so we want to customize this by not showing password, so copy simpleserhr.cs to customserhr.cs
	make dll out of this
   	compile - csc binarysertest.cs /r:customserhr.dll
   	binarysertest.exe Accounting
   	output is  written to dept.bin
   	open dept.bin	
now we have password not shown, instead __extra is shown which we have given in customserhr.cs */