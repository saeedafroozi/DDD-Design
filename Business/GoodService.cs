using Domain.Dto;
using Domain.RepositoryContract;
using Domain.ServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
	internal class GoodService : IGoodService
	{
        private readonly IGoodRepository goodRepository;
        public GoodService(IGoodRepository goodRepository)
        {
            this.goodRepository = goodRepository;
        }
		public OnlineShopServiceResult<GetGoodResponse> Get(GetGoodRequest request)
		{
            var goods= goodRepository.GetAllGoods();

			return new OnlineShopServiceResult<GetGoodResponse>(result: new GetGoodResponse
			{
				Total = 1,
				Data = goods.Result
			});
		}
		public OnlineShopServiceResult<AddItemResponse> AddItem(AddItemRequest request)
		{
			return new OnlineShopServiceResult<AddItemResponse>(result: new AddItemResponse());
		}
	}
}
