using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto;
using Domain.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.WebApi
{
	[Produces("application/json")]
	[Route("api/Default/[action]")]
	public class DefaultController : Controller
	{
		private readonly IGoodService goodService;
		public DefaultController(IGoodService goodService)
		{
			this.goodService = goodService;
		}

		// GET: api/Games/5
		//[HttpGet]
		//public async Task<IActionResult> GetGoods()
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}
		//	return Ok(goodService.AddItem(new Domain.Dto.AddItemRequest {
		//		 Title="کالای اول",
		//	}));
		//}

		// GET: api/Default/PageIndex
		[HttpGet("{pageIndex}")]
		public GetGoodResponse GetGoods(int pageIndex)
		{
			return this.goodService.Get(new GetGoodRequest {
				 PageIndex=pageIndex
			}).Result;
		}


		//// POST: api/Default/title
		[HttpPost]
		public OnlineShopServiceResult<AddItemResponse> AddItem(string title)
		{
			return this.goodService.AddItem(new AddItemRequest {
				 Title=title
			});
		}
	}
}
