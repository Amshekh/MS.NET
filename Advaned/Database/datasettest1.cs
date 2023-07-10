using System;
using System.Data;
using System.Data.SqlClient;

static class Test
{
	private static ShopDataSet FetchProducts()
	{
		ShopDataSet ds = new ShopDataSet();

		SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		SqlDataAdapter da = new SqlDataAdapter("select productno, price, stock from product", con);
		da.Fill(ds.Product);

		return ds;
	}

	private static void PresentProducts(ShopDataSet ds)
	{
		string sep = new string('-', 40);
		Console.WriteLine(sep);
		Console.WriteLine("{0, -12}{1, 10}{2, 8}{3, 10}", "Product No", "Price", "Stock", "Profit");
		Console.WriteLine(sep);
		
		foreach(ShopDataSet.ProductRow row in ds.Product.Rows)
			Console.WriteLine("{0, -12}{1, 10:0.00}{2, 8}{3, 10:0.00}", row.ProductNo, row.Price, row.Stock, row.Profit);

		Console.WriteLine(sep);
		Console.WriteLine("Total Profit: {0, 26:0.00}", ds.Product.Compute("sum(Profit)", null));
	}

	public static void Main()
	{
		ShopDataSet ds = FetchProducts();
		PresentProducts(ds);
	}
}













