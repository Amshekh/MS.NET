using System;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name="product")]
class Product
{
	[Column(Name="productno", IsPrimaryKey=true)]
	public int ProductNo{get; set;}

	[Column]
	public decimal Price{get; set;}

	[Column]
	public int Stock{get; set;}
}

class Shop : DataContext
{
	public Shop(string conStr) : base(conStr){}
}

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



















