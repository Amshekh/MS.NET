using System;
using System.Data;
using System.Data.OleDb;

static class Test
{
	public static void Main()
	{
		OleDbConnection con = new OleDbConnection();
		con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db\\Shop.mdb";
		con.Open();

		OleDbCommand cmd = con.CreateCommand();
		cmd.CommandText = "select productno, price, stock from product";
		
		OleDbDataReader row = cmd.ExecuteReader();
		while(row.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", row.GetInt32(0), row[1], row["stock"]);
		row.Close();

		con.Close();
	}
}











