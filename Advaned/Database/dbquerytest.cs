using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

static class Test
{
	public static void Main()
	{
		ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDB"];
		DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);
		DbConnection con = factory.CreateConnection();
		con.ConnectionString = settings.ConnectionString;
		con.Open();

		DbCommand cmd = con.CreateCommand();
		cmd.CommandText = "select productno, price, stock from product";
		
		DbDataReader row = cmd.ExecuteReader();
		while(row.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", row.GetInt32(0), row[1], row["stock"]);
		row.Close();

		con.Close();
	}
}











