using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExchangeOffice.API.Controllers {
	[Route("api/currency")]
	[ApiController]
	public class CurrencyController : ControllerBase {
		private readonly ICurrencyManager _manager;
		public CurrencyController(ICurrencyManager manager) {
			_manager = manager;
		}

		[Authorize(Roles = "Owner, Manager, Cashier, User")]
		[HttpGet("getall")]
		public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync() {
			return await _manager.GetCurrenciesAsync();
		}

		[Authorize(Roles = "Owner, Manager, Cashier, User")]
		[HttpGet("get")]
		public async Task<CurrencyDto> GetCurrencyAsync(Guid id) {
			return await _manager.GetCurrencyAsync(id);
		}

		[Authorize(Roles = "Owner, Manager")]
		[HttpPost("create")]
		public async Task<CurrencyDto> CreateCurrencyAsync(InsertCurrencyDto data) {
			return await _manager.AddCurrencyAsync(data);
		}

		[Authorize(Roles = "Owner, Manager")]
		[HttpPut("update")]
		public async Task<CurrencyDto> UpdateCurrencyAsync(Guid id, [FromBody]InsertCurrencyDto data) {
			return await _manager.UpdateCurrencyAsync(id, data);
		}

		[Authorize(Roles = "Owner, Manager")]
		[HttpDelete("delete")]
		public async Task<CurrencyDto> DeleteCurrencyAsync(Guid id) {
			return await _manager.DeleteCurrencyAsync(id);
		}
	}
}
