using System;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;

namespace Sales
{
	[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall, IncludeExceptionDetailInFaults=true)]
	public class OrderManager : IOrderManager
	{
		const string conStr = "Data Source=.;Initial Catalog=Shop;Integrated Security=True";

		[OperationBehavior(TransactionScopeRequired=true)]
		public int PlaceOrder(OrderInfo info)
		{
			using(SqlConnection con = new SqlConnection(conStr))
			{
				con.Open();

				SqlCommand cmd = con.CreateCommand();

				cmd.CommandText = "update counter set currentvalue=currentvalue+1 where name='order'";
				cmd.ExecuteNonQuery();
				
				cmd.CommandText = "select currentvalue from counter where name='order'";
				int orderNo = (int) cmd.ExecuteScalar() + 1000;
				
				cmd.CommandText = "insert into orderdetail values (@ordno, @orddt, @custid, @pno, @qty)";
				cmd.Parameters.AddWithValue("@ordno", orderNo);
				cmd.Parameters.AddWithValue("@orddt", DateTime.Now);
				cmd.Parameters.AddWithValue("@custid", info.CustomerId);
				cmd.Parameters.AddWithValue("@pno", info.ProductNo);
				cmd.Parameters.AddWithValue("@qty", info.Quantity);
				cmd.ExecuteNonQuery();

				return orderNo;
			}
		}

		public void SellStock(int productNo, int quantity)
		{
			using(SqlConnection con = new SqlConnection(conStr))
			{
				con.Open();

				SqlCommand cmd = con.CreateCommand();
				
				cmd.CommandText = "update product set stock=stock-@qty where productno=@pno";
				cmd.Parameters.AddWithValue("@pno", productNo);
				cmd.Parameters.AddWithValue("@qty", quantity);
				cmd.ExecuteNonQuery();
			}
		}
	}
}

static class Server
{
	public static void Main()
	{
		ServiceHost host = new ServiceHost(typeof(Sales.OrderManager));
		host.Open();
		
		Console.WriteLine("Enter any key to exit...");
		Console.ReadLine();
		host.Close();
	}
}























