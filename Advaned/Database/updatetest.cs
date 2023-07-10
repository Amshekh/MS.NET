using System;
using System.Data;
using System.Data.SqlClient;

static class Test
{
	public static void Main(string[] args)
	{
		string sql = "update product set stock=stock+5";
		if(args.Length > 0)
			sql += " where productno=" + Convert.ToInt32(args[0]);

		SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();

		SqlCommand cmd = new SqlCommand(sql, con);
		int n = cmd.ExecuteNonQuery();
		Console.WriteLine("Number of updated products: {0}", n);

		con.Close();
	}
}












