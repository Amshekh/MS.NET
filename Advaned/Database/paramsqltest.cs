using System;
using System.Data;
using System.Data.SqlClient;

static class Test
{
	public static void Main(string[] args)
	{
		string customerId = args[0].ToUpper();
		int productNo = Convert.ToInt32(args[1]);
		int quantity = Convert.ToInt32(args[2]);

		SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();
		
		SqlCommand cmd = con.CreateCommand();
		cmd.Transaction = con.BeginTransaction();

		try
		{
			cmd.CommandText = "update counter set currentvalue=currentvalue+1 where name='order'";
			cmd.ExecuteNonQuery();
			
			cmd.CommandText = "select currentvalue from counter where name='order'";
			int orderNo = (int) cmd.ExecuteScalar() + 1000;
			
			cmd.CommandText = "insert into orderdetail values (@ordno, @orddt, @custid, @pno, @qty)";
			cmd.Parameters.AddWithValue("@ordno", orderNo);
			cmd.Parameters.AddWithValue("@orddt", DateTime.Now);
			cmd.Parameters.AddWithValue("@custid", customerId);
			cmd.Parameters.AddWithValue("@pno", productNo);
			cmd.Parameters.AddWithValue("@qty", quantity);
			cmd.ExecuteNonQuery();

			cmd.Transaction.Commit();

			Console.WriteLine("New Order Number: {0}", orderNo);
		}
		catch(Exception ex)
		{
			cmd.Transaction.Rollback();
			Console.WriteLine("Order Failed: {0}", ex.Message);
		}

		con.Close();
	}
}












