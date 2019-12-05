using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataModel
{
    public class SalesMan
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Order> Orders { get; set; }
	}
}
