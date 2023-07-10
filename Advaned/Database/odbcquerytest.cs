using System;
using System.Data;
using System.Data.Odbc;

static class Test
{
	public static void Main()
	{
		OdbcConnection con = new OdbcConnection();
		con.ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};DBQ=db";
		con.Open();

		OdbcCommand cmd = con.CreateCommand();
		cmd.CommandText = "select productno, price, stock from product";
		
		OdbcDataReader row = cmd.ExecuteReader();
		while(row.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", row.GetInt32(0), row[1], row["stock"]);
		row.Close();

		con.Close();
	}
}











