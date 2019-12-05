using Domain.Dto;
using Domain.ServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
	public class GoodService : IGoodService
	{
		public OnlineShopServiceResult<GetGoodResponse> Get(GetGoodRequest request)
		{
			return new OnlineShopServiceResult<GetGoodResponse>(result: new GetGoodResponse
			{
				Total = 1,
				Data = new List<Domain.DataModel.Good> {
					 new Domain.DataModel.Good{
							Id=1,
							 Title="جنس اول"
					 }
				 }
			});
		}
		public OnlineShopServiceResult<AddItemResponse> AddItem(AddItemRequest request)
		{
			return new OnlineShopServiceResult<AddItemResponse>(result: new AddItemResponse());
		}
	}
}
