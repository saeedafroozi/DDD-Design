using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataModel
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime DateTime { get; set; }
		public int CustomerId { get; set; }
		public int SalesManId { get; set; }
		public int GoodId { get; set; }
	}
}
