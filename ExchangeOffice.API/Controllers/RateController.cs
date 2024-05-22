using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/rate")]
	[ApiController]
	public class RateController : ControllerBase {
		private readonly IRateManager _manager;
		public RateController(IRateManager manager) {
			_manager = manager;
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("getall/bytargetcurrency/{targetCurrencyId}")]
		public async Task<IEnumerable<RateDto>> GetRatesByTargetCurrencyIdAsync(Guid targetCurrencyId) {
			return await _manager.GetRatesByTargetCurrencyIdAsync(targetCurrencyId);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("getall/bybasecurrency/{baseCurrencyId}")]
		public async Task<IEnumerable<RateDto>> GetRatesByBaseCurrencyIdAsync(Guid baseCurrencyId) {
			return await _manager.GetRatesByBaseCurrencyIdAsync(baseCurrencyId);
		}

		//[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("getall")]
		public async Task<IEnumerable<RateDto>> GetRatesAsync() {
			return await _manager.GetRatesAsync();
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("get/bycurrencies")]
		public async Task<RateDto> GetRateByCurrenciesAsync(Guid baseCurrency, Guid targetCurrency) {
			return await _manager.GetRateByCurrenciesAsync(baseCurrency, targetCurrency);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpGet("get")]
		public async Task<RateDto> GetRateAsync(Guid id) {
			return await _manager.GetRateAsync(id);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPost("create")]
		public async Task<RateDto> CreateRateAsync(InsertRateDto data) {
			return await _manager.AddRateAsync(data);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpPatch("update")]
		public async Task<RateDto> UpdateRateAsync(Guid id, [FromBody] InsertRateDto data) {
			return await _manager.UpdateRateAsync(id, data);
		}

		[Authorize(Roles = "Owner, Manager, Cashier")]
		[HttpDelete("delete/{id}")]
		public async Task<RateDto> DeleteRateAsync(Guid id) {
			return await _manager.DeleteRateAsync(id);
		}
	}
}
