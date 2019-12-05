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
	[Route("api/Default")]
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
		[HttpGet]
		public OnlineShopServiceResult<GetGoodResponse> GetGoods(int pageIndex)
		{
			return this.goodService.Get(new GetGoodRequest {
				 PageIndex=pageIndex
			} );
		}


		//// POST: api/Default/title
		[HttpPost]
		public OnlineShopServiceResult<AddItemResponse> AddItem([FromBody]string title)
		{
			return this.goodService.AddItem(new AddItemRequest {
				 Title=title
			});
		}

		//// GET: api/Default/5
		//[HttpGet("{id}", Name = "Get")]
		//public string Get(int id)
		//{
		//    return "value";
		//}

		//// POST: api/Default
		//[HttpPost]
		//public void Post([FromBody]string value)
		//{
		//}

		//// PUT: api/Default/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		//// DELETE: api/ApiWithActions/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
