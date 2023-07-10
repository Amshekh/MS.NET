using System;
using System.Data;
using System.Data.SqlClient;

static class Test
{
	public static void Main()
	{
		SqlConnection con = new SqlConnection();
		con.ConnectionString = "Data Source=.;Initial Catalog=Shop;Integrated Security=True";
		con.Open();

		SqlCommand cmd = con.CreateCommand();
		cmd.CommandText = "select productno, price, stock from product";
		
		SqlDataReader row = cmd.ExecuteReader();
		while(row.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", row.GetInt32(0), row[1], row["stock"]);
		row.Close();

		con.Close();
	}
}











