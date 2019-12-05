using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ServiceContract
{
	public interface IGoodService
	{
		OnlineShopServiceResult<GetGoodResponse> Get(GetGoodRequest request);
		OnlineShopServiceResult<AddItemResponse> AddItem(AddItemRequest request);
	}
}
