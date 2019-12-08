using Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class GetGoodResponse
    {
		public int Total { get; set; }
		public IEnumerable<Good> Data { get; set; }
	}
}
