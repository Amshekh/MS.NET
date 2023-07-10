using System;
using System.Linq;
using System.Data.Linq;

static class Test
{
	public static void Main()
	{
		using(Shop shop = new Shop("Data Source=.;Initial Catalog=Shop;Integrated Security=True"))
		{
			Table<Product> products = shop.GetTable<Product>();
			var selection = from p in products where p.Price > 1000 select p;
			
			foreach(var entry in selection)
				Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", entry.ProductNo, entry.Price, entry.Stock);
		}
	}
}



















