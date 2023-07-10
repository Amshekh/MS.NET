using System;
using System.Data;

static class Test
{
	private static ShopDataSet FetchProducts()
	{
		ShopDataSet ds = new ShopDataSet();

		ds.ReadXml("db\\products.xml");

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













