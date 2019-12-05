using Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class GetGoodResponse
    {
		public int Total { get; set; }
		public List<Good> Data { get; set; }
	}
}
