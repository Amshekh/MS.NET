using Sales;
using System;
using System.ServiceModel;
using System.Transactions;

static class Test
{
	public static void Main(string[] args)
	{
		OrderInfo info = new OrderInfo();
		info.CustomerId = args[0].ToUpper();
		info.ProductNo = Convert.ToInt32(args[1]);
		info.Quantity = Convert.ToInt32(args[2]);

		OrderManagerClient client = new OrderManagerClient();

		try
		{
			int orderNo = client.PlaceOrder(info);

			Console.WriteLine("New Order Number: {0}", orderNo);

			client.Close();
		}
		catch(Exception ex)
		{
			Console.WriteLine("Order Failed: {0}", ex.Message);
		}
	}
}















