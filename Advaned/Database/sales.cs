using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Sales
{
	[DataContract]
	public class OrderInfo
	{
		[DataMember]
		public string CustomerId;
		
		[DataMember]
		public int ProductNo;

		[DataMember]
		public int Quantity;
	}

	[ServiceContract]
	public interface IOrderManager
	{
		[OperationContract]
		[TransactionFlow(TransactionFlowOption.Allowed)]
		int PlaceOrder(OrderInfo info);

		[OperationContract]
		[TransactionFlow(TransactionFlowOption.Allowed)]
		void SellStock(int productNo, int quantity);
	}
}



















