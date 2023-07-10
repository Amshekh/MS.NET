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

		ChannelFactory<IOrderManager> factory = new ChannelFactory<IOrderManager>("OrderEndpoint");
		IOrderManager client = factory.CreateChannel();

		try
		{
			int orderNo;
			
			using(TransactionScope tx = new TransactionScope())
			{
				orderNo = client.PlaceOrder(info);
				client.SellStock(info.ProductNo, info.Quantity);
				tx.Complete();
			}

			Console.WriteLine("New Order Number: {0}", orderNo);

			factory.Close();
		}
		catch(Exception ex)
		{
			Console.WriteLine("Order Failed: {0}", ex.Message);
		}
	}
}















