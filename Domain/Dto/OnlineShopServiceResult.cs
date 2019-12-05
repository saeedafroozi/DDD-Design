

using Domain.Dto;
using Domain.Enum;

namespace Domain.Dto
{
	public class OnlineShopServiceResult<TResult> : ServiceResult<TResult, ErrorType>
	{
		public OnlineShopServiceResult(TResult result)
			: this(success: true, result: result, error: ErrorType.None, message: string.Empty)
		{ }

		public OnlineShopServiceResult(ErrorType error, string message = "")
			: this(success: false, result: default(TResult), error: error, message: message)
		{ }

		public OnlineShopServiceResult(bool success, TResult result, ErrorType error, string message)
			: base(result, success, error, message)
		{ }
	}
}
